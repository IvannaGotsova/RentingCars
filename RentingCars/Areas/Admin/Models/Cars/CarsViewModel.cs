using RentingCars.Data.Data.Models.Car;

namespace RentingCars.Areas.Admin.Models.Cars
{
    public class CarsViewModel
    {
        public IEnumerable<CarServiceModel> AddedCars { get; set; }
        = new List<CarServiceModel>();

        public IEnumerable<CarServiceModel> RentedCars { get; set; }
        = new List<CarServiceModel>();
    }
}
