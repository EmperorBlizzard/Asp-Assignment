namespace Infrastructure.Entities;

public class CourseDescriptionEntity
{
    public int Id { get; set; }
    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;
    public string LongDescription { get; set; } = null!;
}
