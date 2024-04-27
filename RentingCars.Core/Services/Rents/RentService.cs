using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RentingCars.Core.Services.Brokers;
using RentingCars.Core.Services.Cars;
using RentingCars.Core.Services.Models.Rents;
using RentingCars.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextData;
        private readonly ICarService carService;
        private readonly IBrokerService brokerService;

        public RentService(RentingCarsDbContext rentingCarsDbContextData, ICarService carService, IBrokerService brokerService)
        {
            this.rentingCarsDbContextData = rentingCarsDbContextData;
            this.carService = carService;
            this.brokerService = brokerService;
        }

        public IEnumerable<RentServiceModel> AllRents()
        {
            return
                this.rentingCarsDbContextData
                .Cars
                .Include(c => c.Broker)
                .Include(c => c.Renter)
                .Where(c => c.RenterId != null)
                .Select(c => new RentServiceModel
                {
                    CarBrand = c.CarBrand,
                    CarModel = c.CarModel,
                    CarImageUrl = c.CarImageUrl,
                    CarPricePerDay = c.CarPricePerDay,
                    BrokerEmail = c.Broker.User.Email,
                    BrokerFullName = c.Broker.User.FirstName + " " + c.Broker.User.LastName,
                    RenterEmail = c.Renter.Email,
                    RenterFullName = c.Renter.FirstName + " " + c.Renter.LastName,
                })
                .ToList();
        }
    }
}
