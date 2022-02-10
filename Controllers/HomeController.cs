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
            //var course = _globalServices.GetCourse(1);
            //var user = _globalServices.GetUser("be760656-941d-4948-825a-f6b09ed1c2ce");
            //_globalServices.MatchCourseWithUser(course, user);

            //var temp1 = _globalServices.GetAllUsersForCourse(1);
            //var temp2 = _globalServices.GetAllCoursesForUser("be760656-941d-4948-825a-f6b09ed1c2ce");

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

        public IActionResult Studentcourses()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Contact()
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
