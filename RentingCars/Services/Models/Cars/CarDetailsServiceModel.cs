using RentingCars.Data.Models.Broker;

namespace RentingCars.Services.Models.Cars
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public string? TypeName { get; init; }

        public BrokerServiceModel Broker { get; init; }
    }
}
