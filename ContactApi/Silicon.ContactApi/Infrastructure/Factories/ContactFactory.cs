using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactEntity Create(ContactRegistrationForm form)
    {
        try
        {
            var dateTime = DateTime.Now;

            return new ContactEntity
            {
                Id = Guid.NewGuid().ToString(),
                FullName = form.FullName,
                Email = form.Email,
                Message = form.Message,
                Created = dateTime,
            };
        }
        catch { }
        return null!;
    }

    public static ContactEntity Create(ContactRegistrationForm form, int serviceId)
    {
        try
        {
            var dateTime = DateTime.Now;

            return new ContactEntity
            {
                Id = Guid.NewGuid().ToString(),
                FullName = form.FullName,
                Email = form.Email,
                ServiceId = serviceId,
                Message = form.Message,
                Created = dateTime,
            };
        }
        catch { }
        return null!;
    }

    public static Contact Create(ContactEntity entity)
    {
        try
        {
            return new Contact
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Service = entity.Service!.ServiceName,
                Message = entity.Message,
            };
        }
        catch { }
        return null!;
    }
}
