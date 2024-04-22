namespace RentingCars.Services.Models.Cars
{
    public class CarIndexServiceModel : ICarModel
    {
        public int Id { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarDescription { get; set; }
        public string? CarAdditionalInformation { get; set; }
        public string? CarImageUrl { get; set; }
    }
}
