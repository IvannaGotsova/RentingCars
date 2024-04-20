using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using RentingCars.Data.Models.Statistics;
using RentingCars.Services.Statistics;

namespace RentingCars.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public StatisticsRequestModel GetStatistics()
        {
            return 
            this.statisticsService.Total();
        }
    }
}
