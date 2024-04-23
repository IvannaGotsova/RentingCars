using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.Data.DataConstants.BrokerConstants;


namespace RentingCars.Data.Data.Entities
{
    public class Broker
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(BrokerPhoneNumberMaxLength)]
        public string? BrokerPhoneNumber { get; set; }
        [Required]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}


