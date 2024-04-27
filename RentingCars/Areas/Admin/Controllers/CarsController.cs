using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentingCars.Areas.Admin.Models.Cars;
using RentingCars.Common;
using RentingCars.Core.Services.Brokers;
using RentingCars.Core.Services.Cars;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IBrokerService brokerService;

        public CarsController(ICarService carService, 
            IBrokerService brokerService)
        {
            this.carService = carService;
            this.brokerService = brokerService;
        }

        public IActionResult Mine()
        {
            var myCars = new CarsViewModel();

            var adminUserId = this.User.Id();

            myCars.RentedCars = this.carService.AllCarsByUserId(adminUserId);

            var adminBrokerId = this.brokerService.GetBrokerId(adminUserId);

            myCars.AddedCars = this.carService.AllCarsByBrokerId(adminBrokerId);

            return View(myCars);
        }
    }
}
