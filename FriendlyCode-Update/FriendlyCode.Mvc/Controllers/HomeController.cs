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
//Öncelikle sanki business katmanında yazılmış bir methot varmışta onu çağırıyoruz.O yüzden Business a gidip yaptk.
//Soyutlamanın anlamı =Aynı yapıda ki bir sürü şeyi kullanma ihtiyacı duyabilirim o yüzden omum soyut bir halini oluşturayım ne zaman istersem onun somutlarını oluştururum mantığıdır.Şu anda da Trainer'larla ilgileniyorum,Tarinerları temsil eden bir interface oluşturayım ve bu interface'in içine(methotlar) bütün Trainerları getir,id'si şu olan Trainer'ı getir,yeni bir Trainer oluştur,Trainer'ı edit/sil gibi temel işlemlerini(CRUD) temsil eden methotları içinde barındıracak bir Trainer classı oluşturmak üzere Business a geçtim.Bunların somutlarını da oluşturmalıyım somut nesne lazım olduğu için içine kod yazacağım;somut ve soyutlar için iki ayrı klasör oluşturdum.(soyut yapı=interface ve abstarct classlar,somut(concrete)=classlar )