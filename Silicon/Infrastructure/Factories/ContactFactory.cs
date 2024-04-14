using Infrastructure.Models;
using WebApp.Models;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create(ContactForm form)
    {
        try
        {
            return new ContactRegistrationForm
            {
                FullName = form.FullName,
                Email = form.Email,
                Service = form.Service,
                Message = form.Message,
            };
        }
        catch { }
        return null!;
    }
}
