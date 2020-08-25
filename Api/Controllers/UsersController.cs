using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyMoon.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetRoutesQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRoutesQueryResponse>> Get([FromQuery] GetRoutesQueryRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
