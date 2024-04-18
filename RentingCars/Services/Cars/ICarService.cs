using RentingCars.Services.Models.Cars;

namespace RentingCars.Services.Cars
{
    public interface ICarService
    {
        IEnumerable<CarIndexServiceModel> LastThreeCars();
        IEnumerable<CarTypeServiceModel> AllCarsTypes();
        bool TypeExists(int typeId);
        int CreateCar(string CarBrand, string CarModel, string Description, string AdditionalInformation, string ImageURL, decimal PricePerDay, int TypeId, int BrokerId);
        CarRequestServiceModel All(string carType = null, string carSearchTerm = null, CarSorting carSorting = CarSorting.Newest, int currentPage = 1,
            int carsPerPage = 1);
        IEnumerable<string> AllCarsTypesNames();
    }
}
