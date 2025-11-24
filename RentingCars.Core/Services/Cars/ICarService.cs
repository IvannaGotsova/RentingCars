using RentingCars.Core.Services.Models.Cars;
using RentingCars.Data.Data.Models.Car;

namespace RentingCars.Core.Services.Cars
{
    public interface ICarService
    {
        IEnumerable<CarIndexServiceModel> LastThreeCars();
        IEnumerable<CarTypeServiceModel> AllCarsTypes();
        bool TypeExists(int typeId);
        int CreateCar(string CarBrand, string CarModel, string Description, string AdditionalInformation, string ImageURL, decimal PricePerDay, int TypeId, int BrokerId, DateOnly carDate);
        CarRequestServiceModel All(string carType = null, string carSearchTerm = null, CarSorting carSorting = CarSorting.Newest, int currentPage = 1,
            int carsPerPage = 1);
        IEnumerable<string> AllCarsTypesNames();

        IEnumerable<CarServiceModel> AllCarsByBrokerId(int brokerId);
        IEnumerable<CarServiceModel> AllCarsByUserId(string userId);

        bool CarExists(int id);
        CarDetailsServiceModel CarDetailsById(int id);

        void Edit(int carId, string carBrand, string carModel, string carDescription, string carAdditionalInformation, string carImageURL, decimal carPricePerDay, int carTypeId, DateOnly carDate);

        bool BrokerWithId(int carId, string currentUserId);

        int CarTypeById(int carId);

        void Delete(int carId);

        bool isRented(int id);

        bool isRentedByUserWithId(int carId, string userId);

        void Rent(int carId, string userId);

        void Return(int carId);
    }
}
