using System.ComponentModel.DataAnnotations;

namespace RentingCars.Services.Models.Cars
{
    public class CarServiceModel : ICarModel
    {
        public int Id { get; init; }
        [Display(Name = "Car Brand")]
        public string? CarBrand { get; init; }
        [Display(Name = "Car Model")]
        public string? CarModel { get; init; }
        [Display(Name = "Car Description")]
        public string? CarDescription { get; init; }
        [Display(Name = "Car Additional Information")]
        public string? CarAdditionalInformation { get; init; }
        [Display(Name = "Car Image URL")]
        public string? CarImageUrl { get; init; }
        [Display(Name = "Car Price Per Day")]
        public decimal CarPricePerDay { get; init; }
        [Required]
        [Display(Name = "Type of the Car")]
        public int TypeId { get; init; }
        public IEnumerable<CarTypeServiceModel> Types { get; set; } = new List<CarTypeServiceModel>();
        [Display(Name = "Is Car Rented")]
        public bool isRented { get; init; }

    }
}
