using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Data.Models.Car;
using RentingCars.Data.Models.Home;
using RentingCars.Services.Car;

namespace RentingCars.Controllers
{
    public class CarsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View(new AllCarsRequestModel());
        }

        [Authorize]
        public IActionResult Mine()
        {
            return View(new AllCarsRequestModel());
        }

        public IActionResult Details(int id)
        {
            return View(new CarDetailsRequestModel());
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddEditCarRequestModel addCarRequestModel)
        {
            return RedirectToAction(nameof(Details), new { id = "1"});
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(new AddEditCarRequestModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, AddEditCarRequestModel editCarRequestModel)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(new CarDetailsRequestModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Return(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


    }
}
