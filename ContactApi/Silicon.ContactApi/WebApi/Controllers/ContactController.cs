using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Create(ContactRegistrationForm form)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var contact = new ContactEntity();

                if (!String.IsNullOrEmpty(form.Service))
                {
                    var serviceId = _context.Services.FirstOrDefault(x => x.ServiceName == form.Service)!.Id;
                    contact = ContactFactory.Create(form, serviceId);
                }
                else
                {
                    contact = ContactFactory.Create(form);
                }

                if (contact != null)
                {
                    var result = await _context.Contacts.AddAsync(contact);
                    _context.SaveChanges();
                    if (result != null)
                    {
                        return Created();
                    }
                    return Problem();
                }
            }
        }
        catch { }
        return BadRequest();
    }
}
