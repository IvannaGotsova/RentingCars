using Microsoft.AspNetCore.Mvc;
using RentingCars.Data.Data.Models.Home;
using RentingCars.Models;
using RentingCars.Core.Services.Cars;
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
            if (this.User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var cars = this.carService.LastThreeCars();
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error400");
            }

            return View();
        }
    }
}
