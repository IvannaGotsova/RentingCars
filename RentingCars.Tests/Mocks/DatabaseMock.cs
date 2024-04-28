using Microsoft.EntityFrameworkCore;
using RentingCars.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static RentingCarsDbContext Instance 
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<RentingCarsDbContext>()
                    .UseInMemoryDatabase("RentingCarsInMemoryDb"
                    + DateTime.Now.Ticks.ToString())
                    .Options;

                return new RentingCarsDbContext(dbContextOptions, false);
            }
        }
    }
}
