using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDE.Common.ModelsDTO.DTO.Authentification;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GoogleSingInController : ControllerBase
    {
        [HttpGet]
        public IActionResult Authentication()
        {
            var client = new AuthenticationApiClient(new Uri("https://bsa-ide.eu.auth0.com"));

            var authorizationUrl = client.BuildAuthorizationUrl()
                .WithResponseType(AuthorizationResponseType.Token)
                .WithResponseMode(AuthorizationResponseMode.FormPost)
                .WithClient("oDlrdb7kNboqqGbWPMzZvlxgHQul87Nh")
                .WithConnection("google-oauth2")
                .WithRedirectUrl("https://localhost:44352/GoogleSingIn/callback")
                .WithScope("openid profile email offline_access")
                .Build();       


            return Redirect(authorizationUrl.ToString());
        }    

        [HttpPost("callback")]
        public async Task<IActionResult> CallbackFormAsync([FromHeader] AuthAccessTokenDTO token)
        {
            var apiClient = new AuthenticationApiClient(new Uri("https://bsa-ide.eu.auth0.com"));
            var userInfo = await apiClient.GetUserInfoAsync(token.access_token);

            return Ok(userInfo);
        }

    }
}