using Infrastructure.Identity;
using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
public class AccountController(AccountService accountService) : Controller
{
    private readonly AccountService _accountService = accountService;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel();

        viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountBasicInfo
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Bio = user.Bio,
            },

            AddressInfo = new AccountAddressInfo
            {
                AddressLine_1 = user.AddressLine_1!,
                AddressLine_2 = user.AddressLine_2!,
                PostalCode = user.PostalCode!,
                City = user.City!,
            }
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if(model.BasicInfo != null)
        {
            if(!string.IsNullOrEmpty(model.BasicInfo.FirstName) && !string.IsNullOrEmpty(model.BasicInfo.LastName))
            {
                var result = await _accountService.UpdateBasicInfoAsync(User, model.BasicInfo);
            }
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (model.AddressInfo != null)
        {
            if (!string.IsNullOrEmpty(model.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(model.AddressInfo.PostalCode) && !string.IsNullOrEmpty(model.AddressInfo.City))
            {
                var result = await _accountService.UpdateAddressInfoAsync(User, model.AddressInfo);
            }
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(AccountSecurityViewModel model)
    {
        if(model.ChangePassword != null)
        {
            if(!string.IsNullOrEmpty(model.ChangePassword.CurrentPassword) && !string.IsNullOrEmpty(model.ChangePassword.NewPassword) && !string.IsNullOrEmpty(model.ChangePassword.ConfirmNewPassword))
            {
                var result = await _accountService.UpdatePasswordAsync(User, model.ChangePassword);

                if(result == true)
                {
                    TempData["PasswordChanged"] = "Password Changed";
                    return RedirectToAction("Security", "Account");
                }
                else
                {
                    TempData["StatusMessage"] = "Password Not Changed";
                    return RedirectToAction("Security", "Account");
                }
            }
        }

        TempData["StatusMessage"] = "Must enter passord correctly";

        return RedirectToAction("Security", "Account");
    }



    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {

        var result = await _accountService.UploadUserProfileAsync(User, file);
        return RedirectToAction("Details", "Account");
    }

    [HttpGet]
    public IActionResult Security()
    {
        return View();
    }
}
