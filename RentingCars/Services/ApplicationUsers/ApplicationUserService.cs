using RentingCars.Data;

namespace RentingCars.Services.ApplicationUsers
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextData;

        public ApplicationUserService(RentingCarsDbContext rentingCarsDbContextData)
        {
            this.rentingCarsDbContextData = rentingCarsDbContextData;
        }

        public string ApplicationUserFullName(string userId)
        {
            var applicationser =
                this.rentingCarsDbContextData
                .ApplicationUsers
                .Find(userId);

            if (string.IsNullOrEmpty(applicationser.FirstName)
                || string.IsNullOrEmpty(applicationser.LastName))
            {
                return null;
            }

            return applicationser.FirstName + " " + applicationser.LastName;
        }
    }
}
