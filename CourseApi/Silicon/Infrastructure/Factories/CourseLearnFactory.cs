using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseLearnFactory
{
    public static CourseLearnModel Create(CourseLearnEntity entity)
    {
        try
        {
            return new CourseLearnModel
            {
                Id = entity.Id,
                LearnText = entity.LearnText,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<CourseLearnModel> Create(IEnumerable<CourseLearnEntity> entities)
    {
        var learn = new List<CourseLearnModel>();
        try
        {
            foreach (var entity in entities)
            {
                learn.Add(Create(entity));
            }
        }
        catch { }
        return learn;
    }
}
