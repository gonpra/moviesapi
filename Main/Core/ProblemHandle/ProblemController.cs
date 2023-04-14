using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Main.Core.ProblemHandle;

#pragma warning disable 1591
public class ProblemController : Controller
{
    
    #pragma warning disable 1591
    [Route(("/problem"))]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Problem([FromServices] IHostEnvironment environment)
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
   
        var problem = Problem();  
        if (environment.IsDevelopment())
        {
            problem = Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        return problem;
    }
}
