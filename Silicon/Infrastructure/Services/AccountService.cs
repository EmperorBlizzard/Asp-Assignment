using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Identity;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WebApp.Factories;

namespace Infrastructure.Services;

public class AccountService(UserManager<ApplicationUser> userManager, DataContext context, IConfiguration configuration)
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;


    public async Task<User> GetUserAsync(ClaimsPrincipal userClaims)
    {
        var nameIdentifier = userClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userEntity = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

        if (userEntity != null)
        {
            return UserFactory.Create(userEntity);
        }

        return null!;
    }


    public async Task<bool> UpdateBasicInfoAsync(ClaimsPrincipal userClaims, AccountBasicInfo basicInfo)
    {
        try
        {
            var nameIdentifier = userClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == nameIdentifier);

            if (userEntity != null)
            {
                userEntity.FirstName = basicInfo.FirstName;
                userEntity.LastName = basicInfo.LastName;
                userEntity.PhoneNumber = basicInfo.Phone;
                userEntity.Bio = basicInfo.Bio;

                _context.Update(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }

        }
        catch { }
        return false;
    }

    public async Task<bool> UpdateAddressInfoAsync(ClaimsPrincipal userClaims, AccountAddressInfo addressInfo)
    {
        try
        {
            var nameIdentifier = userClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

            if (userEntity!.Address != null)
            {
                userEntity.Address!.AddressLine_1 = addressInfo.AddressLine_1;
                userEntity.Address!.AddressLine_2 = addressInfo.AddressLine_2;
                userEntity.Address!.PostalCode = addressInfo.PostalCode;
                userEntity.Address!.City = addressInfo.City;

                _context.Update(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                userEntity.Address = new AddressEntity
                {
                    AddressLine_1 = addressInfo.AddressLine_1,
                    AddressLine_2 = addressInfo.AddressLine_2,
                    PostalCode = addressInfo.PostalCode,
                    City = addressInfo.City,
                };
                _context.Update(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }

        }
        catch { }
        return false;
    }

    public async Task<bool> UpdatePasswordAsync(ClaimsPrincipal userClaims, ChangePassword model)
    {
        try
        {
            var nameIdentifier = userClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == nameIdentifier);
            if (userEntity != null)
            {
                var result = await _userManager.ChangePasswordAsync(userEntity, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    return true;
                }
            }
        }
        catch { }
        return false;
    }


    public async Task<bool> UploadUserProfileAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0)
            {
                var user = await _userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}_{Path.GetExtension(file.FileName)}";

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FilePath:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfileImage = fileName;
                    _context.Update(user); 
                    await _context.SaveChangesAsync();

                    return true;

                }
            }
        }
        catch { }
        return false;
    }


    public async Task<bool> DeleteAccountAsync(ClaimsPrincipal userClaims)
    {
        try
        {
            var nameIdentifier = userClaims.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == nameIdentifier);

            if (userEntity != null)
            {
                var result = _userManager.DeleteAsync(userEntity);

                if(result != null)
                {
                    return true;
                }
            }
        }
        catch { }
        return false;
    }

    
}
