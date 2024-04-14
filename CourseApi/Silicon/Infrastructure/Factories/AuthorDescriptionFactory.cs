using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AuthorDescriptionFactory
{
    public static AuthorDescriptionModel Create(AuthorDescriptionEntity entity)
    {
        try
        {
            return new AuthorDescriptionModel
            {
                Id = entity.Id,
                AuthorImage = entity.AuthorImage,
                AuthorDescription = entity.AuthorDescription,
                AuthorYouTubeSubscribers = entity.AuthorYouTubeSubscribers,
                AuthorFacebookFollowers = entity.AuthorFacebookFollowers,
            };
        }
        catch { }
        return null!;
    }
}
