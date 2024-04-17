using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Common;
using RentingCars.Data.Models.Car;
using RentingCars.Data.Models.Home;
using RentingCars.Services.Brokers;
using RentingCars.Services.Cars;
using RentingCars.Services.Models.Cars;

namespace RentingCars.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IBrokerService brokerService;

        public CarsController(ICarService carService, 
                              IBrokerService brokerService)
        {
            this.carService = carService;
            this.brokerService = brokerService;
        }

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
            if (!this.brokerService.ExistById(this.User.Id()))
            {
                return RedirectToAction(nameof(BrokersController.Become), "Brokers");
            }
            return View(new CarRequestModel
            {
                Types = this.carService.AllCarsTypes()
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CarRequestModel carRequestModel)
        {
            if (!this.brokerService.ExistById(this.User.Id()))
            {
                return RedirectToAction(nameof(BrokersController.Become), "Brokers" );
            }

            if (!this.carService.TypeExists(carRequestModel.TypeId))
            {
                this.ModelState.AddModelError(nameof(carRequestModel.TypeId),
                    "Car type does not exist.");
            }

            if (!ModelState.IsValid)
            {
                carRequestModel.Types = this.carService.AllCarsTypes();

                return View(carRequestModel);
            }

            var brokerId = this.brokerService.GetAgentId(this.User.Id());

            var newCarId = this.carService.CreateCar(carRequestModel.CarBrand, carRequestModel.CarModel, carRequestModel.CarDescription, carRequestModel.CarAdditionalInformation, carRequestModel.CarImageUrl,carRequestModel.CarPricePerDay, 
                carRequestModel.TypeId, brokerId);

            return RedirectToAction(nameof(Details), new { id = newCarId});
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
