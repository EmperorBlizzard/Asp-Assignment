namespace Infrastructure.Entities;

public class CourseLearnEntity
{
    public int Id { get; set; }

    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;
    public string LearnText { get; set; } = null!;
}
