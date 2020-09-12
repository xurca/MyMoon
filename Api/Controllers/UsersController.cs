using Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MyMoon.Application.Users.Commands;
using MyMoon.Application.Users.Queries;
using System;
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
        [ProducesResponseType(typeof(RegisterUserCommandResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RegisterUserCommandResponse>> Register([FromBody] RegisterUserCommandRequest request)
        {
            var resp = await Mediator.Send(request);

            if (!resp.Succeeded)
                return BadRequest(resp);

            return Created(new Uri(string.Empty), resp);
        }

        [HttpPost("/api/account/login")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginUserCommandResponse>> Login([FromBody] LoginUserCommandRequest request)
        {
            var resp = await Mediator.Send(request);

            if (!resp.Succeeded)
                return BadRequest(resp);

            return Ok(resp);
        }

        [HttpGet("/api/auth/providers")]
        [ProducesResponseType(typeof(GetProvidersQueryResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProvidersQueryResponse>> GetProviders()
        {
            return await Mediator.Send(new GetProvidersQueryRequest());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/account/externalLogin")]
        [ProducesResponseType(typeof(ExternalLoginQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExternalLoginQueryResponse>> ExternalLogin(string provider, string returnUrl)
        {
            var resp = await Mediator.Send(new ExternalLoginQueryRequest()
            {
                Provider = provider,
                ReturnUrl = returnUrl,
                RedirectUrl = Url.Action(nameof(ExternalLoginCallback), "Users", new { returnUrl })
            });

            if (!resp.Succeeded)
                return BadRequest(resp);

            return Challenge(resp.Properties, provider);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        [HttpPost]
        [HttpGet]
        [Route("/api/account/externallogincallback")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var resp = await Mediator.Send(new ExternalLoginCallbackCommandRequest() { ReturnUrl = returnUrl });

            if (!resp.Succeeded)
                return BadRequest(resp);

            return Ok(resp);
        }

        [HttpGet]
        [Route("/details")]
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
