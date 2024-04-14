using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ServiceFactory
{
    public static ServiceEntity Create(ServiceRegistrationForm form)
    {
        try
        {
            return new ServiceEntity
            {
                ServiceName = form.ServiceName,
            };
        }
        catch { }
        return null!;
    }

    public static Service Create(ServiceEntity entity)
    {
        try
        {
            return new Service
            {
                Id = entity.Id,
                ServiceName = entity.ServiceName,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<Service> Create(List<ServiceEntity> entities)
    {
        var services = new List<Service>();
        try
        {
            foreach(var entity in entities)
            {
                services.Add(Create(entity));
            }
        }
        catch { }
        return services;
    }
}
