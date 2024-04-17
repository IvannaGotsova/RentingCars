using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Data.Models.Broker;

namespace RentingCars.Controllers
{
    public class BrokersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Become()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeBrokerRequestModel becomeBrokerRequestModel)
        {
            return RedirectToAction(nameof(CarsController.All), "Cars");
        }
    }
}
