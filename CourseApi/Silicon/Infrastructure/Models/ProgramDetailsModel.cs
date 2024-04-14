namespace Infrastructure.Models;

public class ProgramDetailsModel
{
    public int Id { get; set; }
    public string ProgramHeader { get; set; } = null!;
    public string ProgramDescription { get; set; } = null!;
}
