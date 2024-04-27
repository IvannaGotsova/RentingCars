namespace RentingCars.Areas.Admin.Models.Cars
{
    public class CarsViewModel
    {
        public IEnumerable<CarsViewModel> AddedCars { get; set; }
        = new List<CarsViewModel>();

        public IEnumerable<CarsViewModel> RentedCars { get; set; }
        = new List<CarsViewModel>();
    }
}
