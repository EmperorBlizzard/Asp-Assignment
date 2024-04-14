namespace WebApp.Models;

public class Course
{
    public string Id { get; set; } = null!;
    public string Titel { get; set; } = null!;

    public string Author { get; set; } = null!;
    public string OriginalPrice { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public int Hours { get; set; }
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }
    public bool IsDigital { get; set; }
    public bool IsBestseller { get; set; }

    public string? ImageUrl { get; set; }
    public string? BigImageUrl { get; set; }
    public string Category { get; set; } = null!;
}
