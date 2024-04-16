using Microsoft.AspNetCore.Mvc;

namespace RentingCars.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
