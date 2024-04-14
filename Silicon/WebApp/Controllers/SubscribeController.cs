using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers;

public class SubscribeController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeForm form)
    {
        if(ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("https://localhost:7094/api/Subscribe", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Status"] = "You are new subscribe";

                return RedirectToAction("Home", "Default", "subscribe");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["Status"] = "You are already subscribe";

                return RedirectToAction("Home", "Default", "subscribe");
            }
            

        }
        TempData["Status"] = "Somthing went wrong";
        return RedirectToAction("Home", "Default", "subscribe");
    }
}
