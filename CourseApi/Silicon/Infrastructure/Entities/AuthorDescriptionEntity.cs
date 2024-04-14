namespace Infrastructure.Entities;

public class AuthorDescriptionEntity
{
    public int Id { get; set; }
    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;

    public string AuthorImage { get; set; } = null!;
    public string AuthorDescription { get; set; } = null!;

    public string AuthorYouTubeSubscribers { get; set; } = null!;
    public string AuthorFacebookFollowers { get; set; } = null!;
}
