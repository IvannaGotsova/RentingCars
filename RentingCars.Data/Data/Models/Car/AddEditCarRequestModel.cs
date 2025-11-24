using System.ComponentModel.DataAnnotations;

namespace RentingCars.Data.Data.Models.Car
{
    public class AddEditCarRequestModel
    {
        [Required]
        public DateOnly CarDate { get; init; }
    }
}
