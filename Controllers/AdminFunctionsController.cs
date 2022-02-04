using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YogaMockUp.Data;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class AdminFunctionsController : Controller
    {
        private readonly IGlobalServices _GlobalServices;
        private ApplicationDbContext _db;

        public AdminFunctionsController(IGlobalServices globalServices, ApplicationDbContext DB)
        {
            _GlobalServices = globalServices;
            _db = DB;
        }

        [HttpGet]
        public ActionResult EditCourseInfo(int Id)
        {
            var a = _GlobalServices.GetCourse(Id);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditCourseInfo(Course c)
        {
            _GlobalServices.UpdateCourse(c);
            return View(c);
        }

        [HttpGet]
        public ActionResult GetAllCourses()
        {
            List<Course> c = new List<Course>();
            c = _GlobalServices.GetAllCourses();
            return View(c);
        }
        [HttpPost]
        public ActionResult GetAllCourses(List<Course> c)
        {          
            return View(c);
        }

    }
}
