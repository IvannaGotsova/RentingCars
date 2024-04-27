using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Core.Services.Rents;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class RentsController : AdminController
    {
        private readonly IRentService rentService;

        public RentsController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Rents/All")]
        public IActionResult All()
        {
            var rents =
                this.rentService
                .AllRents();

            return View(rents);
        }
    }
}
