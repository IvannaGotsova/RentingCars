namespace RentingCars.Core.Services.Brokers
{
    public interface IBrokerService    
    {
        bool ExistById(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        bool UserHasCarRents(string userId);

        void Create(string userId, string phoneNumber);

        int GetBrokerId(string usetId); 

    }
}
