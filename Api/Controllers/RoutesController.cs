using Microsoft.AspNetCore.Mvc;
using MyMoon.Application.Routes.Queries;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class RoutesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetRoutesQueryResponse>> Get()
        {
            return await Mediator.Send(new GetRoutesQueryRequest());
        }
    }
}
