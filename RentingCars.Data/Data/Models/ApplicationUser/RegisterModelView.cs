using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.Data.DataConstants.ApplicationUserConstants;

namespace RentingCars.Data.Data.Models.ApplicationUserModels
{
    public class RegisterModelView
    {
        [Required]
        [StringLength(AppUserUserNameMaxLength, MinimumLength = AppUserUserNameMinLength)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(AppUserFirstNameMaxLength, MinimumLength = AppUserFirstNameMinLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(AppUserLastNameMaxLength, MinimumLength = AppUserLastNameMinLength)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [StringLength(AppUserEmailMaxLength, MinimumLength = AppUserEmailMinLength)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(AppUserPasswordMaxLength, MinimumLength = AppUserPasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
