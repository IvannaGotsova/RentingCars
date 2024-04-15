using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.ApplicationUserConstants;


namespace RentingCars.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(AppUserFirstNameMaxLength)]
        public string? FirstName { get; set; } 
        [Required]
        [StringLength(AppUserLastNameMaxLength)]
        public string? LastName { get; set; } 

    }
}
