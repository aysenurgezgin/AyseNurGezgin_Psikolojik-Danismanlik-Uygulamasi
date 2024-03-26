using FriendlyCode.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FriendlyCode.Mvc.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        
      
    }
}
//Ana sayfanın açılması demek Mvc uygulamasında;Home Controller'ın Index action'ı tetikleniyordu.(Eğer Controller ve Action söylenmezse default olarakController home,action olarak ta index olsun demiştik Program.cste)pattern=isteğin yapısı,deseni nasıl olacak.