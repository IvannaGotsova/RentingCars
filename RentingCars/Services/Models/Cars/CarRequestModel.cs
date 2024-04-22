using RentingCars.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.CarConstants;

namespace RentingCars.Services.Models.Cars
{
    public class CarRequestModel : ICarModel
    {
        public int Id { get; set; }
        [Display(Name = "Car Brand")]
        [Required]
        [StringLength(CarBrandMaxLength, MinimumLength = CarBrandMinLength)]
        public string? CarBrand { get; init; }
        [Display(Name = "Car Model")]
        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string? CarModel { get; init; }
        [Display(Name = "Car Description")]
        [Required]
        [StringLength(CarDescriptionMaxLength, MinimumLength = CarDescriptionMinLength)]
        public string? CarDescription { get; init; }
        [Display(Name = "Car Additional Information")]
        [Required]
        [StringLength(CarAdditionalInformationMaxLength, MinimumLength = CarAdditionalInformationMinLength)]
        public string? CarAdditionalInformation { get; init; }
        [Display(Name = "Car Image URL")]
        [Required]
        public string? CarImageUrl { get; init; }
        [Display(Name = "Car Price Per Day")]
        [Required]
        [Range(typeof(decimal), "0.00", "2000.00", ConvertValueInInvariantCulture = true, ErrorMessage = "Price of the Car Per Day")]
        public decimal CarPricePerDay { get; init; }
        [Required]
        [Display(Name = "Type of the Car")]
        public int TypeId { get; init; }
        public IEnumerable<CarTypeServiceModel> Types { get; set; } = new List<CarTypeServiceModel>();
        [Display(Name = "Is Car Rented")]
        public bool isRented { get; init; }
    }
}
