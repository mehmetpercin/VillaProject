using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
