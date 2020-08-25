using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyMoon.Application.Users.Commands;
using System.Net;
using System.Threading.Tasks;

namespace MyMoon.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<RegisterUserCommandResponse>> Register([FromBody] RegisterUserCommandRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
