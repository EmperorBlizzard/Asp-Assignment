using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class ChangePassword
{
    [Required(ErrorMessage = "You must enter your password")]
    [Display(Name = "Current Password", Prompt = "Enter your current password")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [Required(ErrorMessage = "You must enter your new password")]
    [Display(Name = "New password", Prompt = "Enter your new password")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set;} = null!;

    [Required(ErrorMessage = "You must confirm your new password")]
    [Display(Name = "Confirm new password", Prompt = "Confirm your new password")]
    [Compare(nameof(NewPassword))]
    [DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set;} = null!;
}
