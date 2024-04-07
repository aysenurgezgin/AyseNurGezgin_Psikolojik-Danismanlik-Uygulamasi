using FriendlyCode.Business.Abstract;
using FriendlyCode.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FriendlyCode.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrainerService _trainerManager;

        public HomeController(ITrainerService trainerManager)
        {
            _trainerManager = trainerManager;
        }

        public IActionResult Index()
        {
            var trainers = _trainerManager.GetAll();
            return View(trainers);
        }

        
      
    }
}
//Ana sayfanın açılması demek Mvc uygulamasında;Home Controller'ın Index action'ı tetikleniyordu.(Eğer Controller ve Action söylenmezse default olarakController home,action olarak ta index olsun demiştik Program.cste)pattern=isteğin yapısı,deseni nasıl olacak.
//Öncelikle sanki business katmanında yazılmış bir methot varmışta onu çağırıyoruz.O yüzden Business a gidip yaptk.
//Soyutlamanın anlamı =Aynı yapıda ki bir sürü şeyi kullanma ihtiyacı duyabilirim o yüzden omum soyut bir halini oluşturayım ne zaman istersem onun somutlarını oluştururum mantığıdır.Şu anda da Trainer'larla ilgileniyorum,Tarinerları temsil eden bir interface oluşturayım ve bu interface'in içine(methotlar) bütün Trainerları getir,id'si şu olan Trainer'ı getir,yeni bir Trainer oluştur,Trainer'ı edit/sil gibi temel işlemlerini(CRUD) temsil eden methotları içinde barındıracak bir Trainer classı oluşturmak üzere Business a geçtim.Bunların somutlarını da oluşturmalıyım somut nesne lazım olduğu için içine kod yazacağım;somut ve soyutlar için iki ayrı klasör oluşturdum.(soyut yapı=interface ve abstarct classlar,somut(concrete)=classlar )

//*Artık TrainerMaager(Business ta methot yazd.göre burada onu çağırabilim.)TrainerManager tipinde bir nesneye ih.var;Program cste yazmıştık neyin içinde var?=conteyner içinde bizim için bekliyor.(ITrainerService dersem sen bana TrainerManager ver demiştikya)Bnuda ctrl+. ile çağır.Dependency enjection yönt ile o conteyner de oluş. trainerManageri aldım _trainerManager içine koymuş oldum.Demek ki artık onu kulanabilirm.
//Bizim  controller içinde ki Index te ki amaç ne?= bu View e bir TrianerViewModel listesi göndermem lazım ki orada bunu  kullanabileyim.Bir değişken tanımladık.(GetAll 3 parametrenin 3ünede null ver kızgınlığı geçsin;değer vermezsen null)