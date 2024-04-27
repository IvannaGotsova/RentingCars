using RentingCars.Core.Services.Models.ApplicationUser;

namespace RentingCars.Core.Services.ApplicationUsers
{
    public interface IApplicationUserService
    {
        string ApplicationUserFullName(string userId);

        IEnumerable<ApplicationUserServiceModel> AllApplicationUsers();
    }
}
