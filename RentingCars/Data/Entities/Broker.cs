using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.BrokerConstants;


namespace RentingCars.Data.Entities
{
    public class Broker
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(BrokerPhoneNumberMaxLength)]
        public string? BrokerPhoneNumber { get; set; }
        [Required]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}


