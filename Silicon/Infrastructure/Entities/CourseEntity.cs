using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CourseEntity
{
    public int Id { get; set; }
    public string CourseName { get; set; } = null!;
    public string CourseAuthor { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    [Column(TypeName = "Money")]
    public double Price { get; set; }
    public bool isOnSale { get; set; }
    public int SaleValue { get; set; }

    public DateTime CourseLenght { get; set; }
    public int PositiveRating { get; set; }
    public int NegativeRating { get; set; }
    public bool BestSeller { get; set; }

}
