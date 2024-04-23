using RentingCars.Core.Services.Models.Cars;
using System.ComponentModel.DataAnnotations;

namespace RentingCars.Data.Data.Models.Car
{
    public class AllCarsRequestModel
    {
        public const int CarsPerPage = 3;

        public string TypeName { get; init; }

        [Display(Name = "Search by keyword")]
        public string SearchTerm { get; init; }

        public CarSorting CarSorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCountCars { get; set; }

        public IEnumerable<string> Types { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; set; }
                                    = new List<CarServiceModel>();

    }
}
