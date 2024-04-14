using Infrastructure.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.CourseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _context.Categories.OrderBy(x => x.CategoryName).ToListAsync();
        return Ok(CategoryFactory.Create(categories));
    }
}
