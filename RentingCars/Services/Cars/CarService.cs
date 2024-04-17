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

    }
}
