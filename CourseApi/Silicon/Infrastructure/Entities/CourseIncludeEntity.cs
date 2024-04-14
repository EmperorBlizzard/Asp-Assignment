namespace Infrastructure.Entities;

public class CourseIncludeEntity
{
    public int Id { get; set; }
    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;

    public string IncludeIcon { get; set; } = null!;
    public string IncludeText { get; set; } = null!;
}
