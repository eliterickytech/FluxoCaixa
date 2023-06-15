using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using System.Threading.Tasks;

namespace Site.Controllers
{
	public class ErrorController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		[Route("/Error")]
		[ApiExplorerSettings(IgnoreApi = true)]
		public async Task<IActionResult> Get([FromServices] IWebHostEnvironment env)
		{
			if (env.EnvironmentName != "Development") return Problem();

			var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
			var exception = context.Error;

			var temp = new Site.Model.Problem()
			{
				Detail = exception.StackTrace,
				Title = exception.Message,
				Type = exception.GetType().Name
			};

			TempData["Error"] = temp;
			return View("~/Views/Error/Index.cshml");

		}
	}
}
