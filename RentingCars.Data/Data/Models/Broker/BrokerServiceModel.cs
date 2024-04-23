using RentingCars.Data.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace RentingCars.Data.Data.Models.Broker
{
    public class BrokerServiceModel
    {
        public string? BrokerPhoneNumber { get; set; }
        public string? BrokerEmail { get; set; }
        public string ? FullName { get; init; }
    }
}
