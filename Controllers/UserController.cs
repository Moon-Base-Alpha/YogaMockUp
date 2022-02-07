using Microsoft.AspNetCore.Mvc;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class UserController : Controller
    {
        private readonly IGlobalServices _GlobalServices;
        public UserController(IGlobalServices globalServices)
        {
            _GlobalServices = globalServices;
        }
        public IActionResult Index()
        {
            var temp1 = _GlobalServices.GetAllUsersForCourse(1);
            var temp2 = _GlobalServices.GetAllCoursesForUser(1);
            return View();
        }
    }
}
