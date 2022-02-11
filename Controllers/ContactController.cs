using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
using YogaMockUp.Models;

namespace YogaMockUp.Controllers
{
    public class ContactController : Controller
    {
        //private readonly IEmailSender _emailSender;

        public ContactController(/*IEmailSender emailSender*/)
        {
            //_emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                try
                {

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(contact.Email);   //Email which you are getting from contact us page 
                    msg.To.Add("yogamockup@gmail.com");         //Where mail will be sent 
                    msg.Subject = contact.Subject;
                    msg.Body = $@"Hello Rajesh, this is a new contact request from your website:<br>

                                Name: {contact.FullName}<br>
                                Email: {contact.Email}<br>
                                Subject: {contact.Subject}<br>
                                Message: ""{contact.Message}""<br>
                                <br>
                                Cheers,<br>
                                From Yoga Shastra contact form";
                    msg.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("yogamockup@gmail.com", "123Asd@1");

                    smtp.EnableSsl = true;

                    smtp.Send(msg);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you! You message have been sent.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = "Sorry we are facing Problem. Please try again.";
                }
            }
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }




        //public async Task<IActionResult> ContactForm(Contact contact)
        //{
        //    var msg = contact.FullName + " " + contact.Message;
        //    await _emailSender.SendEmailAsync(contact.Email, contact.Subject, msg);
        //    ViewBag.ConfirmMsg = "Thank you for your message!";
        //    return View();
        //}
    }
}
