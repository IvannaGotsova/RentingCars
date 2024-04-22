namespace RentingCars.Services.Models.Cars
{
    public interface ICarModel
    {
        string CarBrand { get; }
        string CarModel { get; }
        string CarDescription { get; }
        string CarAdditionalInformation { get; }

    }
}
