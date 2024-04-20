using Microsoft.AspNetCore.Mvc;

namespace RentingCars.Controllers.Api
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
