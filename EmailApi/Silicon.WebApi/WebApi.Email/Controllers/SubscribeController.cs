using Data.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Email.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Create(SubscribeRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            if(!await _context.Subscribers.AnyAsync(x => x.Email == form.Email))
            {
                var subscribeEntity = SubscribeFactory.Create(form);

                _context.Subscribers.Add(subscribeEntity);
                await _context.SaveChangesAsync();

                return Created("", null);
            }
            
            return Conflict();
        }

        return BadRequest();
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete()
    //{
    //    return Ok();
    //}
}
