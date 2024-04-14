using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountBasicInfo
{
    [Required(ErrorMessage = "you must enter your first name")]
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "you must enter your last name")]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    public string LastName { get; set;} = null!;

    [Display(Name = "Email", Prompt = "Enter your email")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Display(Name = "Phone", Prompt ="Enter your phone number")]
    public string? Phone { get; set; }
    [Display(Name = "Bio", Prompt ="Add a short bio...")]
    public string? Bio { get; set; }
}
