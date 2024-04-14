using Infrastructure.Identity;
using Infrastructure.Models;
using WebApp.Models;

namespace WebApp.Factories;

public class UserFactory
{
    public static ApplicationUser Create(SignUpForm form)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            UserName = form.Email
        };

        return applicationUser;
    }

    public static User Create(ApplicationUser userEntity)
    {
        try
        {
            return new User
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                ProfileImage = userEntity.ProfileImage,
                Email = userEntity.Email!,
                UserName = userEntity.Email!,
                PhoneNumber = userEntity.PhoneNumber,
                Bio = userEntity.Bio,
                AddressLine_1 = userEntity.Address?.AddressLine_1,
                AddressLine_2 = userEntity.Address?.AddressLine_2,
                PostalCode = userEntity.Address?.PostalCode,
                City = userEntity.Address?.City,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<User> Create(List<ApplicationUser> list)
    {
        var users = new List<User>();

        try
        {
            foreach(var user in list)
            {
                users.Add(Create(user));
            }
        }
        catch { }
        return users;
    }
}
