using Infrastructure.Entities;

namespace Infrastructure.Models;

public class CourseDescriptionModel
{
    public int Id { get; set; }
    public string ShortDescription { get; set; } = null!;
    public string LongDescription { get; set; } = null!;
}
