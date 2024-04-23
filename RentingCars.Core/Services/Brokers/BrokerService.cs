using RentingCars.Data.Data;
using RentingCars.Data.Data.Entities;

namespace RentingCars.Core.Services.Brokers
{
    public class BrokerService : IBrokerService
    {
        private readonly RentingCarsDbContext rentingCarsDbContext;

        public BrokerService(RentingCarsDbContext rentingCarsDbContext)
        {
            this.rentingCarsDbContext = rentingCarsDbContext;
        }

        public void Create(string userId, string phoneNumber)
        {
            var broker = new Broker()
            {
                UserId = userId,
                BrokerPhoneNumber = phoneNumber
            };

            this.rentingCarsDbContext.Brokers.Add(broker);
            this.rentingCarsDbContext.SaveChanges();
        }

        public bool ExistById(string userId)
        {
            return
                this.rentingCarsDbContext
                .Brokers
                .Any(b => b.UserId == userId);
        }

        public int GetAgentId(string usetId)
        {
            return 
                this.rentingCarsDbContext
                .Brokers
                .FirstOrDefault(b => b.UserId == usetId)
                .Id;   
        }

        public bool UserHasCarRents(string userId)
        {
            return
                 this.rentingCarsDbContext
                 .Cars
                 .Any(c => c.RenterId == userId);
        }

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return
               this.rentingCarsDbContext
               .Brokers
               .Any(b => b.BrokerPhoneNumber == phoneNumber);
        }
    }
}
