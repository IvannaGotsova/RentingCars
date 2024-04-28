using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentingCars.Core.Services.ApplicationUsers;
using RentingCars.Core.Services.Models.ApplicationUser;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IMemoryCache memoryCache;

        public ApplicationUsersController(IApplicationUserService applicationUserService,
            IMemoryCache memoryCache)
        {
            this.applicationUserService = applicationUserService;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Users/All")]
        public IActionResult All()
        {
            var allUsers =
                this.memoryCache
                .Get<IEnumerable<ApplicationUserServiceModel>>(UsersCacheKey);

            if (allUsers == null)
            {
                allUsers = 
                    this.applicationUserService
                    .AllApplicationUsers();


                var cacheOptions =
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.memoryCache.Set(UsersCacheKey, allUsers, cacheOptions);
            }

            return View(allUsers);
        }
    }
}
