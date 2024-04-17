using RentingCars.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.CarConstants;

namespace RentingCars.Services.Models.Cars
{
    public class CarRequestModel
    {
        [Required]
        [StringLength(CarBrandMaxLength, MinimumLength = CarBrandMinLength)]
        public string? CarBrand { get; init; }
        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string? CarModel { get; init; }
        [Required]
        [StringLength(CarDescriptionMaxLength, MinimumLength = CarDescriptionMinLength)]
        public string? CarDescription { get; init; }
        [Required]
        [StringLength(CarAdditionalInformationMaxLength, MinimumLength = CarAdditionalInformationMinLength)]
        public string? CarAdditionalInformation { get; init; }
        [Required]
        [Display(Name = "Image URL")]
        public string? CarImageUrl { get; init; }
        [Required]
        [Range(typeof(decimal), "0.00", "2000.00", ConvertValueInInvariantCulture = true, ErrorMessage = "Price of the Car Per Day")]
        public decimal CarPricePerDay { get; init; }
        [Required]
        [Display(Name = "Type of the Car")]
        public int TypeId { get; init; }
        public IEnumerable<CarTypeServiceModel> Types { get; set; } = new List<CarTypeServiceModel>();
    }
}
