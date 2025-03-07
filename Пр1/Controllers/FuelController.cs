using Microsoft.AspNetCore.Mvc;
using Пр1.Models;
using Пр1.Service;

namespace Пр1.Controllers
{
    public class FuelController : Controller
    {
        private readonly FuelCalculationService _service;

        public FuelController(FuelCalculationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(FuelModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Calculate(model);
                return View("Result", result);
            }
            return View("Index", model);
        }
    }
}
