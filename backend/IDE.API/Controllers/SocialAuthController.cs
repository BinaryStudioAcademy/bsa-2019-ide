using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Authentification;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialAuthController : ControllerBase
    {
        [HttpGet("google")]
        public IActionResult GoogleAuth()
        {
            return SocialAuth(SocialProvider.Google);
        }

        [HttpGet("gitHub")]
        public IActionResult GitHubAuth()
        {
            return SocialAuth(SocialProvider.GitHub);
        }

        [HttpPost("callback")]
        public async Task<IActionResult> CallbackAsync([FromHeader] AuthAccessTokenDTO token)
        {
            if (token.access_token == null)
                return BadRequest();

            var apiClient = new AuthenticationApiClient(new Uri("https://bsa-ide.eu.auth0.com"));
            var userInfo = await apiClient.GetUserInfoAsync(token.access_token);

            return Ok(userInfo);
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