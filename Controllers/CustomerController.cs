using Microsoft.AspNetCore.Mvc;
using YogaMockUp.Services;

namespace YogaMockUp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGlobalServices _GlobalServices;
        public CustomerController(IGlobalServices globalServices)
        {
            _GlobalServices = globalServices;
        }
        public IActionResult Index()
        {
            var temp1 = _GlobalServices.GetAllCustomersForCourse(1);
            var temp2 = _GlobalServices.GetAllCoursesForCustomer(1);
            return View();
        }
    }
}
