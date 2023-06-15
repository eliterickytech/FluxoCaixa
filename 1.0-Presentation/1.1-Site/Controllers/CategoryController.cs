
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Domain.Entities;
using Rickytech.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ILogger<CategoryController> logger, ICategoryServices categoryServices) 
        {
            _logger = logger;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CategoryInput();

            TempData["Category"] = await _categoryServices.GetAllAsync();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(CategoryInput category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryServices.InsertAsync(category);
                _logger.Log(LogLevel.Information, $"Insert Category -- Id: {result} -- Value: {JsonConvert.SerializeObject(category)}");

                return RedirectToAction("Index", "Category");
            }
            ModelState.AddModelError("name", "Preencha a categoria.");

            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryServices.DeleteAsync(Id);
            _logger.Log(LogLevel.Information, $"Delete Category -- Id: {Id} -- Value: {Id}");

            return RedirectToAction("Index", "Category");
        }
    }
}
