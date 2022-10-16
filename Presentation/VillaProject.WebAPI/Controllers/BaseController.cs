using MediatR;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected IActionResult CreateActionResultInstance(Response response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
