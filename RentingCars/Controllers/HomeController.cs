using Microsoft.AspNetCore.Mvc;
using RentingCars.Data.Models.Home;
using RentingCars.Models;
using RentingCars.Services.Car;
using System.Diagnostics;

namespace RentingCars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Index()
        {
            var cars = this.carService.LastThreeCars();
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
