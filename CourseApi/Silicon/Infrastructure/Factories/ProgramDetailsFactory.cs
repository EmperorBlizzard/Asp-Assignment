using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ProgramDetailsFactory
{
    public static ProgramDetailsModel Create(ProgramDetailsEntity entity)
    {
        try
        {
            return new ProgramDetailsModel
            {
                Id = entity.Id,
                ProgramHeader = entity.ProgramHeader,
                ProgramDescription = entity.ProgramDescription,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<ProgramDetailsModel> Create(IEnumerable<ProgramDetailsEntity> entities)
    {
        var programDetails = new List<ProgramDetailsModel>();
        try
        {
            foreach (var entity in entities)
            {
                programDetails.Add(Create(entity));
            }
        }
        catch { }
        return programDetails;
    }
}
