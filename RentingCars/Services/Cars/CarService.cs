using RentingCars.Data;
using RentingCars.Services.Models.Cars;

namespace RentingCars.Services.Car
{
    public class CarService : ICarService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextdata;

        public CarService(RentingCarsDbContext rentingCarsDbContextdata)
        {
            this.rentingCarsDbContextdata = rentingCarsDbContextdata;
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
    }
}
