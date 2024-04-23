using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingCars.Common.ClaimsPrincipalExtensions;
using RentingCars.Data.Data.Models.Broker;
using RentingCars.Core.Services.Brokers;

namespace RentingCars.Controllers
{
    public class BrokersController : Controller
    {
        private readonly IBrokerService brokerService;

        public BrokersController(IBrokerService brokerService)
        {
            this.brokerService = brokerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Become()
        {
            if (this.brokerService.ExistById(this.User.Id()))
            {
                return BadRequest();
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeBrokerRequestModel becomeBrokerRequestModel)
        {
            var userId = this.User.Id();

            if (this.brokerService.ExistById(userId))
            {
                return BadRequest();
            }
            return View();

            if (this.brokerService.UserWithPhoneNumberExists(becomeBrokerRequestModel.BrokerPhoneNumber))
            {
                ModelState.AddModelError(nameof(becomeBrokerRequestModel.BrokerPhoneNumber), "There is already a broker with this phone number. Try again.");
            }

            if (this.brokerService.UserHasCarRents(userId))
            {
                ModelState.AddModelError("Error", "You must have cars in order to become broker!");
            }

            if (!ModelState.IsValid)
            {
                return View(becomeBrokerRequestModel);
            }

            this.brokerService.Create(userId, becomeBrokerRequestModel.BrokerPhoneNumber);

            return RedirectToAction(nameof(CarsController.All), "Cars");
        }
    }
}
