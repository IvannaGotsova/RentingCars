using Microsoft.AspNetCore.Mvc;
using RentingCars.Data.Models.Home;
using RentingCars.Models;
using System.Diagnostics;

namespace RentingCars.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(new IndexViewModel());
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
