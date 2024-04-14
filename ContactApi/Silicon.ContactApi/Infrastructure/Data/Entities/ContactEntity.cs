using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities;

public class ContactEntity
{
    [Key]
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int? ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; }
}
