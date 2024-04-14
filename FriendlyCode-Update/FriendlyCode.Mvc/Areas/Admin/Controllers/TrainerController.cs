using FriendlyCode.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FriendlyCode.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerManager;
        //Dependency Injection
        public TrainerController(ITrainerService trainerManager)
        {
            _trainerManager = trainerManager;
        }

        public IActionResult Index()
        {
            var trainers = _trainerManager.GetAll();
            return View(trainers);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

//Bir area ile çalıştığımız zaman unutmamamna gereken Areayı classın üstüne hemen eklemek.
//Şuan da Prikologlara(trainerlara)ulaşmak istediğimiz için Business katmanına erişmem gerekiyor.Manager deki GetAll'u  çağırmalıyım.;O zaman o manager den bana bir nesne lazım Ve bunu da ctor vasıtasıyla alıyorduk buna da dependency enjection yöntemi deniyordu.;Artık elimde _trainerManager diye bir değişken var ve bu değişken saayesin de trainerManagerde ki methotları çağırabilir kullanabilirm.ve view e gidip modeli de eklemem gerekiyor.Buraya da TrainerViewModel Listesi gelicek (Business katmanımda ki GetAll methodu böyle bir Liste döndürdüğü için)

//Buraya daha öncesinde yazmış olduğum Create methodumu Businesstan çağırmak için methodumu yazmaya başlayabililrim.ve return view diyorum sadece ve view eklemeye gidiyorum.Çünkü bu kod sadece ekrana kullanıcının yeni bir ürün girmesi içn gerekli olan formu açıcak,kayıt falan yapmayacak.Bunun viewi de ;trainer adını girin ,fiyat vs inputların yer ald. form iiçin de barındıran bir tane sayfadır.O sayfanın içinde kaydet diyeceğimiz br butonumuz olucak işte o kaydete basınca şimdi hazırladığımız methodu çalıştırıcaz.
