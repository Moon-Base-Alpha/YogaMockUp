using Microsoft.AspNetCore.Mvc;
using YogaMockUp.Models;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class AdminFunctionsController : Controller
    {
        private readonly IGlobalServices _GlobalServices;
        public AdminFunctionsController(IGlobalServices globalServices)
        {
            _GlobalServices = globalServices;
        }

        [HttpGet]
        public ActionResult EditCourseInfo()
        {
            var a = _GlobalServices.GetCourse(1);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditCourseInfo(Course c)
        {
            return View();
        }

    }
}
