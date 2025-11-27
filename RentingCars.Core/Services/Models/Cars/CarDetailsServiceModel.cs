using RentingCars.Data.Data.Entities;
using RentingCars.Data.Data.Models.Broker;
using RentingCars.Data.Data.Models.Car;

namespace RentingCars.Core.Services.Models.Cars
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public int TypeId { get; init; }
        public string? TypeName { get; init; }

        public BrokerServiceModel Broker { get; init; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
