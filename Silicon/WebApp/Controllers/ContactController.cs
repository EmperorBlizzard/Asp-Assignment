using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;
using static System.Net.WebRequestMethods;

namespace WebApp.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    private string _serviceApiUrl = "https://localhost:7177/api/Service";
    private string _contactApiUrl = "https://localhost:7177/api/Contact";

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var viewModel = new ContactForm();

        var serviceResponse = await _http.GetAsync(_serviceApiUrl);

        if(serviceResponse.IsSuccessStatusCode)
        {
            var services = JsonConvert.DeserializeObject<IEnumerable<ContactServices>>(await serviceResponse.Content.ReadAsStringAsync()); 

            if(services != null)
            {
                viewModel.Services = services;
            }
        }


        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> TakeContact(ContactForm form)
    {

        var contact = ContactFactory.Create(form);

        var content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");

        var contactResponse = await _http.PostAsync(_contactApiUrl, content);

        if(contactResponse.IsSuccessStatusCode)
        {
            ViewData["StatusMessage"] = "OK";
        }
        else
        {
            ViewData["StatusMessage"] = "Error";
        }

        return RedirectToAction("Index", "Contact");
    }

    
}
