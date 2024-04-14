using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Controllers;

public class DefaultController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    public IActionResult Home()
    {
        return View();
    }
}
