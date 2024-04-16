using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentingCars.Data.DataConstants.ApplicationUserConstants;

namespace RentingCars.Data.Models.ApplicationUserModels
{
    public class LoginModelView 
    {
        [Required]
        [StringLength(AppUserUserNameMaxLength, MinimumLength = AppUserUserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
