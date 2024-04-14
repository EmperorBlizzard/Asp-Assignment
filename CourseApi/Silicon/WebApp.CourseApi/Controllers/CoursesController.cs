using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.CourseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll(string category = "",string searchQuery = "",int pageNumber = 1, int pageSize = 6)
    {
        var query = _context.Courses
            .Include(i => i.Category)
            .OrderByDescending(o => o.LastUpdated)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(x => x.Titel.Contains(searchQuery) || x.Author.Contains(searchQuery));
        }

        if (!string.IsNullOrEmpty(category) && category != "all")
        {
            query = query.Where(x => x.Category!.CategoryName == category);
        }

        var totalItemCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);

        var courses = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        var result = new CourseResult
        {
            TotalItems = totalItemCount,
            TotalPages = totalPages,
            Courses = CourseFactory.Create(courses)
        };

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id)
    {
        

        var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (course != null)
        {
            

            var courseDescription = await _context.CourseDescriptions.FirstOrDefaultAsync(x => x.CourseId == id);
            

            var authorDescription = await _context.AuthorDescriptions.FirstOrDefaultAsync(x => x.CourseId == id);
            

            var courseInclude = await _context.CourseIncludes.Where(x => x.CourseId == id).ToListAsync();
            

            var courseLearn = await _context.CourseLearns.Where(x => x.CourseId == id).ToListAsync();
            

            var programDetails = await _context.ProgramDetails.Where(x => x.CourseId == id).ToListAsync();


            if (courseDescription != null && authorDescription != null && courseInclude != null! && courseLearn != null && programDetails != null)
            {
                var result = new OneCourseResult
                {
                    Course = CourseFactory.Create(course),
                    AuthorDescription = AuthorDescriptionFactory.Create(authorDescription),
                    CourseDescription = CourseDescriptionFactory.Create(courseDescription),
                    Includes = CourseIncludeFactory.Create(courseInclude),
                    Learn = CourseLearnFactory.Create(courseLearn),
                    ProgramDetails = ProgramDetailsFactory.Create(programDetails)
                };

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Problem();
                }
            }
        }

        return NotFound();
    }

}
