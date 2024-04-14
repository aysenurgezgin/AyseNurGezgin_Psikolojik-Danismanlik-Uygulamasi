using Microsoft.AspNetCore.Mvc;

namespace FriendlyCode.Mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
