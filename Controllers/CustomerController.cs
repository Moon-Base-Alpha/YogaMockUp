using Microsoft.AspNetCore.Mvc;

namespace YogaMockUp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
