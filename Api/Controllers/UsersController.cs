using Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MyMoon.Application.Users.Commands;
using MyMoon.Application.Users.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyMoon.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        [Route("/Account/Register")]
        [ProducesResponseType(typeof(RegisterUserCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<RegisterUserCommandResponse>> Register([FromBody] RegisterUserCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("/Account/Login")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginUserCommandResponse>> Login([FromBody] LoginUserCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet("/get-providers")]
        [ProducesResponseType(typeof(GetProvidersQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProvidersQueryResponse>> GetProviders()
        {
            return await Mediator.Send(new GetProvidersQueryRequest());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/Account/ExternalLogin")]
        [ProducesResponseType(typeof(ExternalLoginQueryResponse), (int)HttpStatusCode.OK)]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<ExternalLoginQueryResponse>> ExternalLogin(string provider, string returnUrl)
        {
            var res = await Mediator.Send(new ExternalLoginQueryRequest()
            {
                Provider = provider,
                ReturnUrl = returnUrl,
                RedirectUrl = Url.Action(nameof(ExternalLoginCallback), "Users", new { returnUrl })
            });

            return Ok(new
            {
                Url = QueryHelpers.AddQueryString("https://accounts.google.com/o/oauth2/v2/auth", new Dictionary<string, string>()
                {
                    ["response_type"] = "code",
                    ["redirect_uri"] = Url.Action(nameof(ExternalLoginCallback), "Users", new { returnUrl }),
                    ["client_id"] = "672621753090-tj7245kj5k4tc7hm8qjvvc00ok074eje.apps.googleusercontent.com",
                    ["scope"] = "openid profile email",
                    ["flowName"] = "GeneralOAuthFlow",
                    ["client_secret"] = "qsLsiv1AnDTMWEKq1tFhHnPn",
                })
            });

            return Ok(new
            {
                Url = "https://accounts.google.com/o/oauth2/v2/auth/oauthchooseaccount?response_type=code&client_id=672621753090-tj7245kj5k4tc7hm8qjvvc00ok074eje.apps.googleusercontent.com&redirect_uri=https%3A%2F%2Flocalhost%3A5001%2Fsignin-google&scope=openid%20profile%20email&state=CfDJ8LtxORc3_EhHgWLRyr6SAJEV4vMdbLQPbI01Y8_Egx8TZy7cGiRYx0eaUvhqVqz_5QGHl3UoGR7eXxZWpYNmQJSpyhR3fTq_zKg0wfmVfdT9q71DNT0FCi6bK_fsZWdeZD8rMXlmmEQ3bDNAP0K5BYZXaLOr3KUeQ0oZ6jF8szcF03eHSryXCGr5Hi3w5s294ISMd_g2hpTuzQFRwNPx4LCaTGOnzOUJ6l7U_9yJ7YHZQRn9d-1PCUlsTi8WUYSRMuK5STXtxmv9IljLalxHKrE&flowName=GeneralOAuthFlow"
            });

            return Challenge(res.Properties, provider);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/Account/ExternalLoginCallback")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var res = await Mediator.Send(new ExternalLoginCallbackQueryRequest() { ReturnUrl = returnUrl });
            return Ok(res);
        }

        //[HttpGet]
        //[Route("details")]
        //[Authorize]
        //public ActionResult Details()
        //{
        //    return Ok(new
        //    {
        //        Claims = HttpContext.User.Claims.Select(x => new
        //        {
        //            x.Type,
        //            x.Value
        //        }),
        //        HttpContext.User.Identity.Name,
        //        HttpContext.User.Identity.IsAuthenticated
        //    });
        //}
    }
}
