using RentingCars.Services.Models.Cars;

namespace RentingCars.Services.Car
{
    public interface ICarService
    {
        IEnumerable<CarIndexServiceModel> LastThreeCars();
    }
}
