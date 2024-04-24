﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RentingCars.Common;
using RentingCars.Data.Data.Models.Car;
using RentingCars.Data.Data.Models.Home;
using RentingCars.Core.Services.Brokers;
using RentingCars.Core.Services.Cars;
using RentingCars.Core.Services.Models.Cars;
using AutoMapper;

namespace RentingCars.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IBrokerService brokerService;
        private readonly IMapper mapper;

        public CarsController(ICarService carService, 
                              IBrokerService brokerService,
                              IMapper mapper)
        {
            this.carService = carService;
            this.brokerService = brokerService;
            this.mapper = mapper;
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

        public IActionResult Details(int id, string information)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            var carModel = this.carService.CarDetailsById(id);

            if (information != carModel.GetInformation())
            {
                return BadRequest();
            }

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
                return RedirectToAction(nameof(BrokersController.Become), "Brokers");
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

            var newCarId = this.carService.CreateCar(carRequestModel.CarBrand, carRequestModel.CarModel, carRequestModel.CarDescription, carRequestModel.CarAdditionalInformation, carRequestModel.CarImageUrl, carRequestModel.CarPricePerDay,
                carRequestModel.TypeId, brokerId);

            return RedirectToAction(nameof(Details), new { id = newCarId, information = carRequestModel.GetInformation()});
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            if (!this.carService.BrokerWithId(id, this.User.Id())
                && !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var car =
                this.carService
                .CarDetailsById(id);

            var carTypeId =
                this.carService
                .CarTypeById(car.Id);

            var carModel = new CarRequestModel()
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                CarDescription = car.CarDescription,
                CarAdditionalInformation = car.CarAdditionalInformation,
                CarImageUrl = car.CarImageUrl,
                CarPricePerDay = car.CarPricePerDay,
                TypeId = car.TypeId,
                Types = this.carService.AllCarsTypes()
            };

            return View(carModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CarRequestModel carRequestModel)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            if (!this.carService.BrokerWithId(id, this.User.Id())
                && !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!this.carService.TypeExists(carRequestModel.TypeId))
            {
                this.ModelState.AddModelError(nameof(carRequestModel.TypeId), "Type does not exist.");
            }

            if (!ModelState.IsValid)
            {
                carRequestModel.Types =
                    this.carService.AllCarsTypes();

                return View(carRequestModel);
            }

            this.carService.Edit(id, carRequestModel.CarBrand, carRequestModel.CarModel, carRequestModel.CarDescription, carRequestModel.CarAdditionalInformation, carRequestModel.CarImageUrl, carRequestModel.CarPricePerDay, carRequestModel.TypeId);

            return RedirectToAction(nameof(Details), new { id = id, information = carRequestModel.GetInformation() });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            if (!this.carService.BrokerWithId(id, this.User.Id())
                && !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var car =
                this.carService
                .CarDetailsById(id);

            var carModel = new CarDetailsRequestModel()
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                CarDescription = car.CarDescription,
                CarAdditionalInformation = car.CarAdditionalInformation,
                CarImageUrl = car.CarImageUrl,
                CarPricePerDay = car.CarPricePerDay,
            };

            return View(carModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(CarDetailsRequestModel carDetailsRequestModel)
        {
            if (!this.carService.CarExists(carDetailsRequestModel.Id))
            {
                return BadRequest();
            }

            if (!this.carService.BrokerWithId(carDetailsRequestModel.Id, this.User.Id())
                && !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            this.carService
                .Delete(carDetailsRequestModel.Id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id)
        {
            if (!this.carService.CarExists(id))
            {
                return BadRequest();
            }

            if (this.brokerService.ExistById(this.User.Id())
                && !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            if (this.carService.isRented(id))
            {
                return BadRequest();
            }

            this.carService.Rent(id, this.User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Return(int id)
        {
            if (!this.carService.CarExists(id) ||
                !this.carService.isRented(id))
            {
                return BadRequest();
            }

            if (!this.carService.isRentedByUserWithId(id, this.User.Id()))
            {
                return Unauthorized();
            }

            this.carService.Return(id);

            return RedirectToAction(nameof(Mine));
        }


    }
}
