using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentingCars.Core.Services.ApplicationUsers;
using RentingCars.Core.Services.Cars;
using RentingCars.Core.Services.Models.Cars;
using RentingCars.Data.Data;
using RentingCars.Data.Data.Entities;
using RentingCars.Data.Data.Models.Broker;
using RentingCars.Data.Data.Models.Car;
using System.Runtime.Intrinsics.Arm;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace RentingCars.Core.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextdata;
        private readonly IApplicationUserService applicationUserService;
        private readonly IMapper mapper;

        public CarService(RentingCarsDbContext rentingCarsDbContextdata,
            IApplicationUserService applicationUserService, 
            IMapper mapper)
        {
            this.rentingCarsDbContextdata = rentingCarsDbContextdata;
            this.applicationUserService = applicationUserService;
            this.mapper = mapper;
        }

        public IEnumerable<CarTypeServiceModel> AllCarsTypes()
        {
            return
                this.rentingCarsDbContextdata
                .Types
                .Select(t => new CarTypeServiceModel
                {
                    Id = t.Id,
                    TypeName = t.TypeName
                }).ToList();
        }

        public IEnumerable<CarIndexServiceModel> LastThreeCars()
        {
            return
                this.rentingCarsDbContextdata
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarIndexServiceModel
                {
                    Id = c.Id,
                    CarBrand = c.CarBrand,
                    CarDescription = c.CarDescription,
                    CarAdditionalInformation = c.CarAdditionalInformation,
                    CarImageUrl = c.CarImageUrl,
                })
                .Take(3);
        }

        public bool TypeExists(int typeId)
        {
            return
                this.rentingCarsDbContextdata
                .Types
                .Any(t => t.Id == typeId);
        }

        public int CreateCar(string CarBrand, string CarModel, string CarDescription, string CarAdditionalInformation, string CarImageURL, decimal CarPricePerDay, int CarTypeId, int CarBrokerId, DateOnly CarDate)
        {
            var car = new Car
            {
                CarBrand = CarBrand,
                CarModel = CarModel,
                CarDescription = CarDescription,
                CarAdditionalInformation = CarAdditionalInformation,
                CarImageUrl = CarImageURL,
                CarPricePerDay = CarPricePerDay,
                TypeId = CarTypeId,
                BrokerId = CarBrokerId,
                CarDate = CarDate
            };

            this.rentingCarsDbContextdata.Cars.Add(car);
            this.rentingCarsDbContextdata.SaveChanges();

            return car.Id;
        }

        public CarRequestServiceModel All(string carType = null, string carSearchTerm = null, CarSorting carSorting = CarSorting.NewestAdded, int currentPage = 1, int carsPerPage = 1)
        {
            var carsRequest = this.rentingCarsDbContextdata
                .Cars
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(carType))
            {
                carsRequest =
                    this.rentingCarsDbContextdata
                    .Cars
                    .Where(c => c.Type.TypeName == carType);
            }

            if (!string.IsNullOrWhiteSpace(carSearchTerm))
            {

                bool isNumber = int.TryParse(carSearchTerm, out int number);

                carsRequest =
                       carsRequest
                       .Where(cr =>
                       cr.CarBrand.ToLower().Contains(carSearchTerm.ToLower()) ||
                       cr.CarModel.ToLower().Contains(carSearchTerm.ToLower()) ||
                       cr.CarDescription.ToLower().Contains(carSearchTerm.ToLower()) ||
                       cr.CarAdditionalInformation.ToLower().Contains(carSearchTerm.ToLower()));
            }


            carsRequest = carSorting switch
            {
                CarSorting.NewestAdded => carsRequest
                .OrderByDescending(cr => cr.Id),
                CarSorting.OldestAdded => carsRequest
                .OrderBy(cr => cr.Id),
                CarSorting.LowestPrice => carsRequest
                .OrderBy(cr => cr.CarPricePerDay),
                CarSorting.HighestPrice => carsRequest
                .OrderByDescending(cr => cr.CarPricePerDay),
                CarSorting.NotRentedFirst => carsRequest
                .OrderBy(cr => cr.RenterId != null)
                .ThenByDescending(cr => cr.Id),
                CarSorting.RentedFirst => carsRequest
                .OrderBy(cr => cr.RenterId == null),
                CarSorting.NewestDate => carsRequest.
                OrderByDescending(cr => cr.CarDate),
                CarSorting.OldestDate => carsRequest.
                OrderBy(cr => cr.CarDate),

            };

            var cars = carsRequest
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(cr => new CarServiceModel
                {
                    Id = cr.Id,
                    CarBrand = cr.CarBrand,
                    CarModel = cr.CarModel,
                    CarDescription = cr.CarDescription,
                    CarAdditionalInformation = cr.CarAdditionalInformation,
                    CarImageUrl = cr.CarImageUrl,
                    CarPricePerDay = cr.CarPricePerDay,
                    isRented = cr.RenterId != null,
                    CarDate = cr.CarDate
                })
                .ToList();

            var totalCars = carsRequest.Count();

            return new CarRequestServiceModel()
            {
                TotalCountCars = totalCars,
                Cars = cars
            };
        }

        public IEnumerable<string> AllCarsTypesNames()
        {
            return
                this.rentingCarsDbContextdata
                .Types
                .Select(t => t.TypeName)
                .Distinct()
                .ToList();
        }

        public IEnumerable<CarServiceModel> AllCarsByBrokerId(int brokerId)
        {
            var cars =
                this.rentingCarsDbContextdata
                .Cars
                .Where(c => c.BrokerId == brokerId)
                .ToList();

            return ConvertToModel(cars);
        }

        public IEnumerable<CarServiceModel> AllCarsByUserId(string userId)
        {
            var cars =
                this.rentingCarsDbContextdata
                .Cars
                .Where(c => c.RenterId == userId)
                .ToList();

            return ConvertToModel(cars);
        }

        private List<CarServiceModel> ConvertToModel(List<Car> cars)
        {
            var convertCars = cars
                .Select(c => new CarServiceModel()
                {
                    Id = c.Id,
                    CarBrand = c.CarBrand,
                    CarModel = c.CarModel,
                    CarDescription = c.CarDescription,
                    CarAdditionalInformation = c.CarAdditionalInformation,
                    CarImageUrl = c.CarImageUrl,
                    CarPricePerDay = c.CarPricePerDay,
                    isRented = c.RenterId != null,
                    CarDate = c.CarDate
                })
                .ToList();

            return convertCars;
        }

        public bool CarExists(int id)
        {
            return
                rentingCarsDbContextdata
                .Cars
                .Any(c => c.Id == id);
        }

        public CarDetailsServiceModel CarDetailsById(int id)
        {
            return
                rentingCarsDbContextdata
                .Cars
                .Where(c => c.Id == id)
                .Include(c => c.Comments)
                .Select(c => new CarDetailsServiceModel()
                {
                    Id = c.Id, 
                    CarBrand = c.CarBrand,
                    CarModel = c.CarModel,
                    CarDescription = c.CarDescription,
                    CarAdditionalInformation = c.CarAdditionalInformation,
                    CarImageUrl = c.CarImageUrl,
                    CarPricePerDay = c.CarPricePerDay,
                    isRented = c.RenterId != null,
                    TypeName = c.Type.TypeName,
                    CarDate = c.CarDate,
                    Broker = new BrokerServiceModel()
                    {
                        FullName = this.applicationUserService.ApplicationUserFullName(c.Broker.UserId),
                        BrokerPhoneNumber = c.Broker.BrokerPhoneNumber,
                        BrokerEmail = c.Broker.User.Email 
                    },
                    Comments = c.Comments.ToList()
                })
                .FirstOrDefault();
        }

        public void Edit(int carId, string carBrand, string carModel, string carDescription, string carAdditionalInformation, string carImageURL, decimal carPricePerDay, int carTypeId, DateOnly carDate)
        {
            var car = this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            car.CarBrand = carBrand;
            car.CarModel = carModel;
            car.CarDescription = carDescription;
            car.CarAdditionalInformation = carAdditionalInformation;
            car.CarImageUrl = carImageURL;
            car.CarPricePerDay = carPricePerDay;
            car.TypeId = carTypeId;
            car.CarDate = carDate;

            this.rentingCarsDbContextdata.SaveChanges();
        }

        public bool BrokerWithId(int carId, string currentUserId)
        {
            var car =
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            var broker =
                this.rentingCarsDbContextdata
                .Brokers
                .FirstOrDefault(b => b.Id == car.BrokerId);

            if (broker == null)
            {
                return false;
            }

            if (broker.UserId != currentUserId)
            {
                return false;
            }

            return true;
        }

        public int CarTypeById(int carId)
        {
            return
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId).TypeId;
        }
        public void Delete(int carId)
        {
            var car =
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            this.rentingCarsDbContextdata.Remove(car);
            this.rentingCarsDbContextdata.SaveChanges();
        }

        public bool isRented(int id)
        {
            return
                this.rentingCarsDbContextdata
                .Cars
                .Find(id)
                .RenterId != null;
        }

        public bool isRentedByUserWithId(int carId, string userId)
        {
            var car =
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            if (car == null)
            {
                return false;
            }

            if (car.RenterId != userId)
            {
                return false;
            }

            return true;
        }

        public void Rent(int carId, string userId)
        {
            var car =
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            car.RenterId = userId;
            this.rentingCarsDbContextdata.SaveChanges();
        }

        public void Return(int carId)
        {
            var car =
                this.rentingCarsDbContextdata
                .Cars
                .Find(carId);

            car.RenterId = null;
            this.rentingCarsDbContextdata.SaveChanges();
        }
    }
}
