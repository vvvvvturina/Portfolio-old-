using Microsoft.AspNetCore.Mvc;
using Misc.Services.EmailService;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private IEmailSender EmailSender;

    public ContactController(IEmailSender _emailSender)
    {
        EmailSender = _emailSender;
    }

    // GET
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact([FromForm] User userData)
    {

        var message = new Message(new string[] {"bunkergames616@gmail.com"}, "Users Data",
            $"Email:{userData.Email}\nName:{userData.Name}\nSubject:{userData.Subject}\nMessage:\n{userData.Message}");
        await EmailSender.SendEmailAsync(message);
        return Ok();

    }
}