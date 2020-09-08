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
        [Route("/api/account/register")]
        [ProducesResponseType(typeof(RegisterUserCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<RegisterUserCommandResponse>> Register([FromBody] RegisterUserCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("/api/account/login")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginUserCommandResponse>> Login([FromBody] LoginUserCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet("/api/auth/providers")]
        [ProducesResponseType(typeof(GetProvidersQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProvidersQueryResponse>> GetProviders()
        {
            return await Mediator.Send(new GetProvidersQueryRequest());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/account/externalLogin")]
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

            return Challenge(res.Properties, provider);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/account/externallogincallback")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var res = await Mediator.Send(new ExternalLoginCallbackQueryRequest() { ReturnUrl = returnUrl });
            return Ok(res);
        }

        [HttpGet]
        [Route("details")]
        [Authorize]
        public ActionResult Details()
        {
            return Ok(new
            {
                Claims = HttpContext.User.Claims.Select(x => new
                {
                    x.Type,
                    x.Value
                }),
                HttpContext.User.Identity.Name,
                HttpContext.User.Identity.IsAuthenticated
            });
        }
    }
}
