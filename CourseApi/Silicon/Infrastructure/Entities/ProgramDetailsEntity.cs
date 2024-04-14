namespace Infrastructure.Entities;

public class ProgramDetailsEntity
{
    public int Id { get; set; }
    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;

    public string ProgramHeader { get; set; } = null!;
    public string ProgramDescription { get; set; } = null!;
}
