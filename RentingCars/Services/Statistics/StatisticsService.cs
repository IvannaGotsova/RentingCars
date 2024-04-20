using RentingCars.Data;
using RentingCars.Data.Models.Statistics;

namespace RentingCars.Services.Statistics
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
