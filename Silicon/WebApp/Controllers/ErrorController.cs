using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ErrorController : Controller
{
    [Route("/denied")]
    public IActionResult Denied()
    {
        return View();
    }

    [HttpGet]
    [Route("notfound")]
    public IActionResult PageNotFound()
    {
        string originalPath = "unknown";
        if(HttpContext.Items.ContainsKey("originalPath"))
        {
            originalPath = HttpContext.Items["originalPath"] as string;
        }
        return View();
    }
}
