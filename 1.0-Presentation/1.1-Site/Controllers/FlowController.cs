using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Interfaces;
using Rickytech.Domain.Interfaces.Services;
using System.Data;
using System.Threading.Tasks;

namespace Site.Controllers
{
	public class FlowController : Controller
	{
        private readonly ILogger<FlowController> _logger;
        private readonly IFlowServices _flowServices;
        private readonly ICategoryServices _categoryServices;

        public FlowController(ILogger<FlowController> logger, IFlowServices flowServices, ICategoryServices categoryServices)
        {
            _logger = logger;
            _flowServices = flowServices;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
		{
            var model = new FlowInput();

            TempData["Category"] = await _categoryServices.GetAllAsync();
            TempData["Flow"] = await _flowServices.GetAllAsync();

            return View(model);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(FlowInput flow)
        {
            if (ModelState.IsValid)
            {
                var result = await _flowServices.InsertAsync(flow);
                _logger.Log(LogLevel.Information, $"Insert Flow -- Id: {result} -- Value: {JsonConvert.SerializeObject(flow)}");

                return RedirectToAction("Index", "Flow");
            }
            return View(flow);
        }
    }
}
