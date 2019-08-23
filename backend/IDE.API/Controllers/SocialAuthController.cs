using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.User;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Authentification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialAuthController : ControllerBase
    {
        private readonly ISocialAuthService _socialAuthService;
        private SocialProvider _socialProvider;
        private Uri _authUri;

        public SocialAuthController(ISocialAuthService socialAuthService, IConfiguration configuration)
        {
            _socialAuthService = socialAuthService;
            _authUri = new Uri(configuration["Auth0:Domain"]);
        }


        [HttpGet("google")]
        public IActionResult GoogleAuth()
        {
            _socialProvider = SocialProvider.Google;
            return SocialAuth(_socialProvider);
        }

        [HttpGet("gitHub")]
        public IActionResult GitHubAuth()
        {
            _socialProvider = SocialProvider.GitHub;
            return SocialAuth(_socialProvider);
        }

        [HttpPost("callback")]
        public async Task<IActionResult> CallbackAsync([FromHeader] AuthAccessTokenDTO token)
        {
            if (token.access_token == null)
                return BadRequest();
            var apiClient = new AuthenticationApiClient(_authUri);
            var userInfo = await apiClient.GetUserInfoAsync(token.access_token);

            var socialAuthUserDetailsDTO = new SocialAuthUserDetailsDTO
            {
                AccountId = userInfo.UserId,
                Provider = _socialProvider,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                FullName = userInfo.FullName,
                NickName = userInfo.NickName,
                Picture = userInfo.Picture,
                Email = userInfo.Email
            };

            var authUserDto =  await _socialAuthService.LogInAsync(socialAuthUserDetailsDTO);

            return Ok(authUserDto);
        }

        private IActionResult SocialAuth(SocialProvider socialProvider)
        {
            var client = new AuthenticationApiClient(_authUri);
            var socialProviderString = string.Empty;
            switch (socialProvider)
            {
                case SocialProvider.Google:
                    socialProviderString = "google-oauth2";
                    break;
                case SocialProvider.GitHub:
                    socialProviderString = "github";
                    break;
                default:
                    throw new NotFoundException(nameof(SocialProvider), socialProvider.ToString());
            }

            var authorizationUrl = client.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Token)
                .WithResponseMode(AuthorizationResponseMode.FormPost)
                .WithClient("Dhw2JmB6zMwZtI6FWsrqktAt4UlvQWle") // move to envirenment
                .WithConnection(socialProviderString)
                .WithRedirectUrl($"{Request.Scheme}://{Request.Host}/SocialAuth/callback")
                .WithScope("openid profile email")
                .Build();

            return Redirect(authorizationUrl.ToString());
        }
    }
}