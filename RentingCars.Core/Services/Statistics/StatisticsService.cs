using RentingCars.Data.Data;
using RentingCars.Data.Data.Models.Statistics;
using RentingCars.Data.Data.Models.Statistics;

namespace RentingCars.Core.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly RentingCarsDbContext rentingCarsDbContextData;

        public StatisticsService(RentingCarsDbContext rentingCarsDbContextData)
        {
            this.rentingCarsDbContextData = rentingCarsDbContextData;
        }

        public StatisticsRequestModel Total()
        {
            var totalCars
                = rentingCarsDbContextData
                .Cars
                .Count();

            var totalRents
                = rentingCarsDbContextData
                .Cars
                .Where(c => c.RenterId != null)
                .Count();

            return new StatisticsRequestModel
            {
                TotalCars = totalCars,
                TotalRents = totalRents
            };
        }
    }
}
