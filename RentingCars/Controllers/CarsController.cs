﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public IActionResult All([FromQuery] AllCarsRequestModel allCarsRequestModel)
        {
            var requestResult =
                this.carService
                .All(
                    allCarsRequestModel.TypeName,
                    allCarsRequestModel.SearchTerm,
                    allCarsRequestModel.CarSorting,
                    allCarsRequestModel.CurrentPage,
                    AllCarsRequestModel.CarsPerPage);

            allCarsRequestModel.TotalCountCars = requestResult.TotalCountCars;
            allCarsRequestModel.Cars = requestResult.Cars;

            var carTypes = this.carService.AllCarsTypesNames();
            allCarsRequestModel.Types = carTypes;

            return View(allCarsRequestModel);
        }

        [Authorize]
        public IActionResult Mine()
        {
            IEnumerable<CarServiceModel> myCars = null;

            var userId = this.User.Id();

            if (this.brokerService.ExistById(userId))
            {
                var currentBrokerId = this.brokerService.GetAgentId(userId);

                myCars = this.carService.AllCarsByBrokerId(currentBrokerId);
            }
            else
            {
                myCars = this.carService.AllCarsByUserId(userId);
            }

            return View(myCars);
        }

        public IActionResult Details(int id)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            var carModel = this.carService.CarDetailsById(id);

            return View(carModel);
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
