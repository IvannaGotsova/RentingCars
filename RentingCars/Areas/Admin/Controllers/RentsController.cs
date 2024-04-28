using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentingCars.Core.Services.Models.ApplicationUser;
using RentingCars.Core.Services.Models.Rents;
using RentingCars.Core.Services.Rents;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class RentsController : AdminController
    {
        private readonly IRentService rentService;
        private readonly IMemoryCache memoryCache;

        public RentsController(IRentService rentService,
            IMemoryCache memoryCache)
        {
            this.rentService = rentService;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Rents/All")]
        public IActionResult All()
        {
            var allRents =
                this.memoryCache
                .Get<IEnumerable<RentServiceModel>>(RentsCacheKey);

            if (allRents == null)
            {
                allRents =
                    this.rentService
                    .AllRents();


                var cacheOptions =
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.memoryCache.Set(RentsCacheKey, allRents, cacheOptions);
            }

            return View(allRents);
        }
    }
}
