using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Misc.Services.EmailService;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private IEmailSender _emailSender;

    public ContactController(ILogger<ContactController> logger, IEmailSender emailSender)
    {
        _logger = logger;
        _emailSender = emailSender;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SendEmailDefault(MimeMessage messageToSend)
    { 
        _emailSender.SendEmail("send this version");
        return RedirectToAction("Index");
    }
    

    /*[HttpPost]
    public async Task<IActionResult> Contact([FromForm] User userData)
    {

        var message = new Message(new string[] {"bunkergames616@gmail.com"}, "Users Data",
            $"Email:{userData.Email}\nName:{userData.Name}\nSubject:{userData.Subject}\nMessage:\n{userData.Message}");
        await EmailSender.SendEmailAsync(message);
        return Ok();

    }*/
}