using Infrastructure.Models;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
public class CoursesController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    private string _categoryApiUrl = "https://localhost:7205/api/Categories";
    private string _courseApiUrl = "https://localhost:7205/api/Courses";

    [HttpGet]
    public async Task<IActionResult> Index(string category = "", string searchQuery = "" ,int pageNumber = 1, int pageSize = 6)
    {
        var viewModel = new CoursesViewModel();

        var categoryResponse = await _http.GetAsync(_categoryApiUrl);
        
        
        if (categoryResponse.IsSuccessStatusCode)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await categoryResponse.Content.ReadAsStringAsync());


            if(categories != null)
            {
                viewModel.Categories = categories;
            }
        }

        var courseResponse = await _http.GetAsync($"{_courseApiUrl}?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}");

        if (courseResponse.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<CourseResult>(await courseResponse.Content.ReadAsStringAsync());


            if (result != null)
            {
                viewModel.Courses = result.Courses!;

                viewModel.Pagination = new Pagination
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = result.TotalPages,
                    TotalCount = result.TotalItems,
                };

            }

        }
         return View(viewModel);
    }

    [HttpGet("course/{Id}")]
    public async Task<IActionResult> Details(string Id)
    {
        var viewModel = new CourseDetailsViewModel();

        var courseDetailsApiUrl = $"{_courseApiUrl}/{Id}";

        var courseDetailsResponese = await _http.GetAsync(courseDetailsApiUrl);

        if(courseDetailsResponese.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<OneCourseResult>(await courseDetailsResponese.Content.ReadAsStringAsync());

            if (result != null)
            {
                viewModel.Course = result.Course;
                viewModel.AuthorDescription = result.AuthorDescription;
                viewModel.CourseDescription = result.CourseDescription;
                viewModel.Includes = result.Includes;
                viewModel.Learn = result.Learn;
                viewModel.ProgramDetails = result.ProgramDetails;
            }
        }


        return View(viewModel);
    }

    [Route("/Course/Youtube")]
    public IActionResult Youtube()
    {
        return new RedirectResult("https://www.youtube.com/@utbildning-epnsverige");
    }

    [Route("/Course/Facebook")]
    public IActionResult Facebook()
    {
        return new RedirectResult("https://www.facebook.com/hansmattinlassei");
    }
}
