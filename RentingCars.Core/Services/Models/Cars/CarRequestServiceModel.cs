using RentingCars.Data.Data.Models.Car;

namespace RentingCars.Core.Services.Models.Cars
{
    public class CarRequestServiceModel
    {
        public int TotalCountCars { get; set; }

        public IEnumerable<CarServiceModel> Cars 
            = new List<CarServiceModel>();
    }
}
