using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.CarConstants;


namespace RentingCars.Data.Entities
{
    public class Car
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string? CarBrand { get; set; }
        [Required]
        [MaxLength(CarModelMaxLength)]
        public string? CarModel { get; set; }
        [Required]
        [MaxLength(CarDescriptionMaxLength)]
        public string? CarDescription { get; set; }
        [Required]
        [MaxLength(CarAdditionalInformationMaxLength)]
        public string? CarAdditionalInformation { get; set; }
        [Required]
        public string? CarImageUrl { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "2000.00", ConvertValueInInvariantCulture = true)]
        public decimal CarPricePerDay { get; set; }
        [Required]
        public int TypeId { get; set; }
        public Type? Type { get; set; }
        [Required]
        public int BrokerId { get; set; }
        public Broker? Broker { get; set; }
        public string? RenterId { get; set; }

    }
}

