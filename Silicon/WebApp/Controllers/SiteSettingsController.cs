﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SiteSettingsController : Controller
{
    public IActionResult Theme(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
        };
        Response.Cookies.Append("theme", mode, option);

        return Ok();
    }

    [HttpPost]
    public IActionResult Consent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
            HttpOnly = true,
            Secure = true,
        };
        Response.Cookies.Append("consent", "true", option);

        return Ok();
    }
}
