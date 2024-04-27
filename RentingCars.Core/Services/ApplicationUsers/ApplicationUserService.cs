using RentingCars.Data.Data;
using RentingCars.Core.Services.ApplicationUsers;
using RentingCars.Core.Services.Models.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using RentingCars.Core.Services.Models.Cars;

namespace RentingCars.Core.Services.ApplicationUsers
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextData;

        public ApplicationUserService(RentingCarsDbContext rentingCarsDbContextData)
        {
            this.rentingCarsDbContextData = rentingCarsDbContextData;
        }

        public IEnumerable<ApplicationUserServiceModel> AllApplicationUsers()
        {
            var allUsers =
                new List<ApplicationUserServiceModel>();

            var brokers =
                this.rentingCarsDbContextData
                .Brokers
                .Include(b => b.User)
                .Select(b => new ApplicationUserServiceModel
                {
                    ApplicationUserEmail = b.User.Email,
                    ApplicationUserFullName = b.User.FirstName + " " + b.User.LastName,
                    ApplicationUserPhoneNumber = b.BrokerPhoneNumber
                })
                .ToList();

            allUsers.AddRange(brokers);

            var applicationUsers =
                this.rentingCarsDbContextData
                .ApplicationUsers
                .Where(au => !this.rentingCarsDbContextData.Brokers.Any(b => b.UserId == au.Id))
                 .Select(aus => new ApplicationUserServiceModel
                 {
                     ApplicationUserEmail = aus.Email,
                     ApplicationUserFullName = aus.FirstName + " " + aus.LastName,
                     ApplicationUserPhoneNumber = string.Empty
                 })
                .ToList();

            allUsers.AddRange(applicationUsers);

            return allUsers;
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
