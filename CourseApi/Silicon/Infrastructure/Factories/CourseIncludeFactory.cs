using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseIncludeFactory
{
    public static CourseIncludeModel Create(CourseIncludeEntity entity)
    {
        try
        {
            return new CourseIncludeModel
            {
                Id = entity.Id,
                IncludeIcon = entity.IncludeIcon,
                IncludeText = entity.IncludeText,
            };
        }
        catch { }
        return null!;
    }
    public static IEnumerable<CourseIncludeModel> Create(IEnumerable<CourseIncludeEntity> entities)
    {
        var includes = new List<CourseIncludeModel>();
        try
        {
            foreach (var entity in entities)
            {
                includes.Add(Create(entity));
            }
        }
        catch { }
        return includes;
    }

}
