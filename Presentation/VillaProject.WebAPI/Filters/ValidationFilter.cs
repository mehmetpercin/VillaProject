using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.WebAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                var response = ErrorResponse.Fail(string.Join(Environment.NewLine, errors), 400);
                context.Result = new BadRequestObjectResult(response);
                return;
            }
            await next();
        }
    }
}
