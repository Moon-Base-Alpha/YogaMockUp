using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YogaMockUp.Models;

namespace YogaMockUp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(Contact contact)
        {
            var msg = contact.FullName + " " + contact.Message;
            await _emailSender.SendEmailAsync(contact.Email, contact.Subject, msg);
            ViewBag.ConfirmMsg = "Thank you for your message";
            return View();
        }
    }
}
