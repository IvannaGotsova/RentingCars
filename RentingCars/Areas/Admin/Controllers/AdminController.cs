using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentingCars.Areas.Admin.AdminConstants;

namespace RentingCars.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area(AreaName)]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
