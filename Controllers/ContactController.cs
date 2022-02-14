using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using YogaMockUp.Data;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class ContactController : Controller
    {
        //private readonly IEmailSender _emailSender;
        private ApplicationDbContext _db;
        private readonly IContactServices _ContactServices;

        public ContactController(IContactServices contactServices, ApplicationDbContext DB /*IEmailSender emailSender*/)
        {
            //_emailSender = emailSender;
            _ContactServices = contactServices;
            _db = DB;
        }

        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(contact.Email);   //Email which you are getting from contact us page 
                    msg.To.Add("yogamockup@gmail.com");         //Where mail will be sent 
                    msg.To.Add(contact.Email);
                    msg.Subject = contact.Subject;
                    msg.Body = $@"Hello, this is a copy of the request from website yogashastra.org:<br>

                                Name: {contact.FirstName} {contact.LastName}<br>
                                Email: {contact.Email}<br>
                                Subject: {contact.Subject}<br>
                                Message: ""{contact.Message}""<br>
                                <br>
                                Cheers,<br>
                                From Yoga Shastra";
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

                    if (ModelState.IsValid)
                    {
                        _ContactServices.CreateContact(contact);
                        await _db.SaveChangesAsync();
                    }
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

        //[HttpGet]
        //public IActionResult CreateContact(int id)
        //{
        //    return View(new Contact());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateContact(Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _ContactServices.CreateContact(contact);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("GetAllContact");
        //    }
        //    return View(contact);
        //}


        [HttpGet]
        public IActionResult GetAllContacts()
        {
            List<Contact> contact = new List<Contact>();
            contact = _ContactServices.GetAllContacts();
            return View(contact);
        }

        [HttpPost]
        public IActionResult GetAllContacts(List<Contact> contact)
        {
            return View(contact);
        }

        [HttpGet]
        public IActionResult ContactDetails(int id)
        {
            var contact = _ContactServices.GetContact(id);
            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _ContactServices.DeleteContact(id);
            await _ContactServices.SaveChangesAsync();

            return RedirectToAction("GetAllContacts");
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
