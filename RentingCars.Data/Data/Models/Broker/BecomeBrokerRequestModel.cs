using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.Data.DataConstants.BrokerConstants;

namespace RentingCars.Data.Data.Models.Broker
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
