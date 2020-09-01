using Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMoon.Application.Users.Commands;
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
        //[Route("login")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginUserCommandResponse>> Login([FromBody] LoginUserCommandRequest request)
        {
            return await Mediator.Send(request);
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
