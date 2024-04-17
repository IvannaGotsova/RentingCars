using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.BrokerConstants;

namespace RentingCars.Data.Models.Broker
{
    public class BecomeBrokerRequestModel
    {
        [Required]
        [StringLength(BrokerPhoneNumberMaxLength, MinimumLength =BrokerPhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string BrokerPhoneNumber { get; init; }
    }
}
