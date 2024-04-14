namespace Infrastructure.Models;

public class AuthorDescriptionModel
{
    public int Id { get; set; }
    public string AuthorImage { get; set; } = null!;
    public string AuthorDescription { get; set; } = null!;
    public string AuthorYouTubeSubscribers { get; set; } = null!;
    public string AuthorFacebookFollowers { get; set; } = null!;
}
