using Infrastructure.Entities;
using Infrastructure.Identity;
using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AccountService accountService) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly AccountService _accountService = accountService;

    #region sign up

    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpForm form)
    {
        if (ModelState.IsValid)
        {
            string roleName = "User";

            if (!await _userManager.Users.AnyAsync())
            {
                roleName = "Admin";
            }

            if (!await _userManager.Users.AnyAsync(x => x.Email == form.Email))
            {
                var appUser = UserFactory.Create(form);

                if ((await _userManager.CreateAsync(appUser, form.Password)).Succeeded)
                {
                    appUser = await _userManager.FindByEmailAsync(form.Email);

                    if (appUser != null)
                    {
                        await _userManager.AddToRoleAsync(appUser, roleName);

                        if ((await _signInManager.PasswordSignInAsync(appUser.Email!, form.Password, false, false)).Succeeded)
                            return LocalRedirect("/");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Please try again.";
                }

            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email address already exist";
            }
        }
        return View();
    }

    #endregion

    #region sign in
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInForm form)
    {
        if (ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, form.RememberMe, false)).Succeeded)
                return LocalRedirect("/");
        }

        ViewData["StatusMessage"] = "Incorrect email or password";
        return View();
    }

    #endregion

    #region sign out

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }

    #endregion


    #region delete account 

    [HttpPost]
    public async Task<IActionResult> Delete(AccountSecurityViewModel model)
    {
        if (model.Delete != null)
        {
            var result = await _accountService.DeleteAccountAsync(User);
            if(result != false)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Home", "Default");
            }
            else
            {
                ViewData["StatusMessage"] = "Account not deleted! Please try again";
            }
        }
        ViewData["StatusMessage"] = "Must allow delete";

        return RedirectToAction("Security", "Account");
    }

    #endregion
}
