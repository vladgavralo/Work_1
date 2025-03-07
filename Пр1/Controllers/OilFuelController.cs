using Microsoft.AspNetCore.Mvc;
using Пр1.Models;
using Пр1.Service;

namespace Пр1.Controllers
{
    public class OilFuelController : Controller
    {
        private readonly FuelCalculationService _service;

        public OilFuelController(FuelCalculationService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(OilFuelModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CalculateOil(model);
                return View("Result", result);
            }
            return View("Index", model);
        }
    }
}
