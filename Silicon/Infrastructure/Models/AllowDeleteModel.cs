using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace Infrastructure.Models;

public class AllowDeleteModel
{
    [CheckboxRequired]
    [Display(Name = "AllowDelete")]
    public bool AllowDelete { get; set; }
}
