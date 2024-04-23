using System.ComponentModel.DataAnnotations;

namespace RentingCars.Data.Data.Models.Car
{
    public class CarDetailsRequestModel
    {
        public int Id { get; init; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarDescription { get; set; }
        public string? CarAdditionalInformation { get; set; }
        public string? CarImageUrl { get; set; }
        public decimal CarPricePerDay { get; set; }
    }
}
