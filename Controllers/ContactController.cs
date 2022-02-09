using Microsoft.AspNetCore.Mvc;

namespace YogaMockUp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
