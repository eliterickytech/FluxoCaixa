using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rickytech.Application.RickytechApp.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Rickytech.Application.RickytechApp.Result;
using Microsoft.Extensions.Options;
using System;

namespace Site.Controllers
{
    public class DashboardController : Controller
    {
		private readonly IFlowServices _flowServices;
		private readonly ILogger<DashboardController> _logger;

        public DashboardController(IFlowServices flowServices, ILogger<DashboardController> logger)
		{
			_flowServices = flowServices;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
        {
			if (ViewData["Dashboard"] == null)
			{
				var result = await _flowServices.GetAllAsync();
				ViewData["Dashboard"] = result;

			}

			return View();
        }

		public async Task<IActionResult> IndexRedirect(DateTime startDate, DateTime endDate)
		{
			var result = await _flowServices.GetAllAsync();
			ViewData["Dashboard"] = result.ToList().Where(x => x.OperationDate >= startDate && x.OperationDate <= endDate).ToList();

			return View("~/Views/Dashboard/Index.cshtml");
		}

		public async Task<bool> Filter(DateTime startDate, DateTime endDate)
		{
		
			return true;
		}

	}
}
