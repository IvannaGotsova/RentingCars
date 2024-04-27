using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Core.Services.ApplicationUsers;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserService applicationUserService;

        public ApplicationUsersController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Users/All")]
        public IActionResult All()
        {
            var allUsers =
                this.applicationUserService
                .AllApplicationUsers();

            return View(allUsers);
        }
    }
}
