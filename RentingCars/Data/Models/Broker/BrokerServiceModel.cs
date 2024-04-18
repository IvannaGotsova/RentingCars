using RentingCars.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace RentingCars.Data.Models.Broker
{
    public class BrokerServiceModel
    {
        public string? BrokerPhoneNumber { get; set; }
        public string? BrokerEmail { get; set; }
    }
}
