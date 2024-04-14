using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountAddressInfo
{
    [Required(ErrorMessage ="you must enter your address line")]
    [Display(Name ="AddressLine 1", Prompt = "Enter your address line")]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "AddressLine 2", Prompt = "Enter your second address line")]
    public string? AddressLine_2 { get; set;}

    [Required(ErrorMessage = "you must enter your postal code")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "you must enter your city")]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
