using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Models.Rents
{
    public class RentServiceModel
    {
        public string CarBrand { get; init; }
        public string CarModel { get; init; }
        public string CarImageUrl { get; init; }
        public decimal CarPricePerDay{ get; init; }
        public string BrokerFullName { get; init; }
        public string BrokerEmail { get; init; }
        public string RenterFullName { get; init; }
        public string RenterEmail { get; init; }
    }
}
