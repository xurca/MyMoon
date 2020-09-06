using Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMoon.Application.Users.Commands;
using MyMoon.Application.Users.Queries;
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

        [HttpPost]
        [Route("/Account/ExternalLogin")]
        [ProducesResponseType(typeof(ExternalLoginQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExternalLoginQueryResponse>> ExternalLogin(string provider, string returnUrl)
        {
            var res = await Mediator.Send(new ExternalLoginQueryRequest()
            {
                Provider = provider,
                ReturnUrl = returnUrl,
                RedirectUrl = Url.Action(nameof(ExternalLoginCallback), "Users", new { returnUrl })
            });

            var resp = new ChallengeResult(provider, res.Properties);

            return Ok(resp);
        }

        [HttpGet]
        [Route("/Account/ExternalLoginCallback")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var res = await Mediator.Send(new ExternalLoginCallbackQueryRequest() { ReturnUrl = returnUrl });
            return res;
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
