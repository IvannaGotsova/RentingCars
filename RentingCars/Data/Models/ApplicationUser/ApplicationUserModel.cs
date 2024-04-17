using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentingCars.Data.DataConstants.ApplicationUserConstants;

namespace RentingCars.Data.Models.ApplicationUserModels
{

    public class ApplicationUserModel
    {
        public string Id { get; set; } = null!;
        [Required]
        [StringLength(AppUserUserNameMaxLength, MinimumLength = AppUserUserNameMinLength)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(AppUserFirstNameMaxLength, MinimumLength = AppUserFirstNameMinLength)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(AppUserLastNameMaxLength, MinimumLength = AppUserLastNameMinLength)]
        public string? LastName { get; set; }
    }
}
