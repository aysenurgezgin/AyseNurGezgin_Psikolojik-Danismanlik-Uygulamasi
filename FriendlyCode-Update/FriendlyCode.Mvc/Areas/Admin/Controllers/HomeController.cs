using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FriendlyCode.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


//Temel işlemlerimşz için kullanacağımız alan(admin ana sayfası)
//Bunun View'i yok şuan ve biz oluşturabilirizz aslında ama Views klasörün de olması gerekenlerş de eklemeliyiz;
//1)Shared olmalı içinde de Layout olmalı
//2)ViewStart ViewImport dosyalrı onlar mecbur değil ama olursa işimize yaramış oluyor.
//O yüzden Mvc içinde ki normal Views kalsörü içinde ki Shared klasörünü seçip ctrl tuşuna basarak ViewStart ViewImport onların 3'ünü seçip kopyalayıp benim Views klasörüme yapıştırıyorum.

//!  Diğerinin Admin olarak old söylememiz yeterli.Admin için deki Home controller
//içinde classımızın üstüne köşeli parantez açı(Mvc de attribute deniyor)Home
   // controllerı bir attribte özellik nitelik tanımlamış oluyorum.
   // Tanımlayacağım attribute Area("area name i yazılır")

