using Microsoft.AspNetCore.Mvc;

namespace RentingCars.Controllers
{
    public class BrokersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
