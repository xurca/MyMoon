using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMoon.Application.Routes.Queries;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class RoutesController : BaseController
    {
        [HttpGet]
        [Route("/api/routes")]
        [ProducesResponseType(typeof(GetRoutesQueryResponse), (int)StatusCodes.Status200OK)]
        public async Task<ActionResult<GetRoutesQueryResponse>> Get([FromQuery] GetRoutesQueryRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
