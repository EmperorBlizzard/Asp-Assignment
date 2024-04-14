using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class ContactForm
{
    [Required]
    [Display(Name ="Full Name", Prompt ="Enter your full name")]
    public string FullName { get; set; } = null!;

    [Required]
    [Display(Name = "Email", Prompt = "Enter your email")]
    public string Email { get; set; } = null!;

    public IEnumerable<ContactServices>? Services { get; set; }

    [Display(Name = "Service")]
    public string? Service {  get; set; }

    [Required]
    [Display(Name = "Message", Prompt = "Enter your message")]
    public string Message { get; set; } = null!;
}
