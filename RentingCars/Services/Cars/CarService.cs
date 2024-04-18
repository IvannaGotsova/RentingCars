using RentingCars.Data;
using RentingCars.Data.Entities;
using RentingCars.Data.Models.Car;
using RentingCars.Services.Models.Cars;
using System.Reflection.Metadata.Ecma335;

namespace RentingCars.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextdata;

        public CarService(RentingCarsDbContext rentingCarsDbContextdata)
        {
            this.rentingCarsDbContextdata = rentingCarsDbContextdata;
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
                    CarImageUrl = c.CarImageUrl
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

        public int CreateCar(string CarBrand, string CarModel, string CarDescription, string CarAdditionalInformation, string CarImageURL, decimal CarPricePerDay, int CarTypeId, int CarBrokerId)
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
                BrokerId = CarBrokerId
            };

            this.rentingCarsDbContextdata.Cars.Add(car);
            this.rentingCarsDbContextdata.SaveChanges();

            return car.Id;
        }

        public CarRequestServiceModel All(string carType = null, string carSearchTerm = null, CarSorting carSorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
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
                CarSorting.Newest => carsRequest
                .OrderByDescending(cr => cr.Id),
                CarSorting.Price => carsRequest
                .OrderBy(cr => cr.CarPricePerDay),
                CarSorting.NotRentedFirst => carsRequest
                .OrderBy(cr => cr.RenterId != null)
                .ThenByDescending(cr => cr.Id),
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
                    isRented = cr.RenterId != null
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
    }
}
