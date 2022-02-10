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

            return View();
        }
    }
}
