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

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialAuthController : ControllerBase
    {
        private readonly ISocialAuthService _socialAuthService;
        private SocialProvider _socialProvider;

        public SocialAuthController(ISocialAuthService socialAuthService)
        {
            _socialAuthService = socialAuthService;
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

            var apiClient = new AuthenticationApiClient(new Uri("https://bsa-ide.eu.auth0.com"));
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
            var client = new AuthenticationApiClient(new Uri("https://bsa-ide.eu.auth0.com"));
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
                .WithClient("oDlrdb7kNboqqGbWPMzZvlxgHQul87Nh")
                .WithConnection(socialProviderString)
                .WithRedirectUrl("https://localhost:44352/SocialAuth/callback")
                .WithScope("openid profile email offline_access")
                .Build();

            return Redirect(authorizationUrl.ToString());
        }
    }
}