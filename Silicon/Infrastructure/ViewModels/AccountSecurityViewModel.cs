using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace Infrastructure.ViewModels;

public class AccountSecurityViewModel
{
    public ChangePassword ChangePassword { get; set; } = null!;

    public AllowDeleteModel Delete { get; set; } = null!;
}
