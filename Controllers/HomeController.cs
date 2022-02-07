using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IGlobalServices _globalServices;

        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IGlobalServices IGS)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _globalServices = IGS;
        }

        public IActionResult Index()
        {
            //_globalServices.SeedStuff();
            return View();

            //var signedIn = _signInManager.IsSignedIn(User);
            
            //if (!signedIn)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Admin");
            //}
        }

        public IActionResult CarouselEx()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
