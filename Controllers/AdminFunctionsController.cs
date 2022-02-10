using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YogaMockUp.Data;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    [Authorize(Roles = "Superadmin, Admin")]
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

        [HttpGet]
        public IActionResult CreateCourse(int id)
        {
            return View(new Course());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _GlobalServices.CreateCourse(course);
                await _db.SaveChangesAsync();
                return RedirectToAction("GetAllCourses");
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _GlobalServices.DeleteCourse(id);
            await _GlobalServices.SaveChangesAsync();

            return RedirectToAction("GetAllCourses");
        }

        [HttpGet]
        public IActionResult CourseDetails(int id)
        {
            var course = _GlobalServices.GetCourse(id);
            return View(course);
        }
    }
}
