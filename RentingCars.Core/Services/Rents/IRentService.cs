using RentingCars.Core.Services.Models.Rents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Rents
{
    public interface IRentService
    {
        IEnumerable<RentServiceModel> AllRents();
    }
}
