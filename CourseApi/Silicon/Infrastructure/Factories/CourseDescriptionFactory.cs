using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseDescriptionFactory
{
    public static CourseDescriptionModel Create(CourseDescriptionEntity entity)
    {
        try
        {
            return new CourseDescriptionModel
            {
                Id = entity.Id,
                ShortDescription = entity.ShortDescription,
                LongDescription = entity.LongDescription,
            };
        }
        catch { }
        return null!;
    }
}
