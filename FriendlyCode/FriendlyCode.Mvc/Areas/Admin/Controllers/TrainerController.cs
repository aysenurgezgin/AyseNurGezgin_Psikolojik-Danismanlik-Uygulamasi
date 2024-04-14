using FriendlyCode.Business.Abstract;
using FriendlyCode.Core.ViewModels;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrainerViewModel trainerViewModel)
        {
            _trainerManager.Create(trainerViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        { 
            TrainerViewModel editedTrainer=_trainerManager.GetById(id);
            return View(editedTrainer);
        }
        [HttpPost]
        public IActionResult Edit(TrainerViewModel editedTrainer) 
        {
            _trainerManager.Update(editedTrainer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
           TrainerViewModel deletedTrainer = _trainerManager.GetById(id);
           return View(deletedTrainer);
        }
    }
}

//Bir area ile çalıştığımız zaman unutmamamna gereken Areayı classın üstüne hemen eklemek.
//Şuan da Prikologlara(trainerlara)ulaşmak istediğimiz için Business katmanına erişmem gerekiyor.Manager deki GetAll'u  çağırmalıyım.;O zaman o manager den bana bir nesne lazım Ve bunu da ctor vasıtasıyla alıyorduk buna da dependency enjection yöntemi deniyordu.;Artık elimde _trainerManager diye bir değişken var ve bu değişken saayesin de trainerManagerde ki methotları çağırabilir kullanabilirm.ve view e gidip modeli de eklemem gerekiyor.Buraya da TrainerViewModel Listesi gelicek (Business katmanımda ki GetAll methodu böyle bir Liste döndürdüğü için)

//Buraya daha öncesinde yazmış olduğum Create methodumu Businesstan çağırmak için methodumu yazmaya başlayabililrim.ve return view diyorum sadece ve view eklemeye gidiyorum.Çünkü bu kod sadece ekrana kullanıcının yeni bir ürün girmesi içn gerekli olan formu açıcak,kayıt falan yapmayacak.Bunun viewi de ;trainer adını girin ,fiyat vs inputların yer ald. form iiçin de barındıran bir tane sayfadır.O sayfanın içinde kaydet diyeceğimiz br butonumuz olucak işte o kaydete basınca şimdi hazırladığımız methodu çalıştırıcaz.
//2.Create methoduma post old için bir attribute eklemeliyim bu action u niteleyen    [HttpPost] yazınca olur.
//Debug işlemiyle bu verieirin buraya geldiğişni gördük,bu verielri alıp kaydetmek için hazırladığım business katmanım da ki ilgili methoduma yollayabilirm._trainerManager deki Create i kullanarak onun içine trainerViewModeli yollayacaksın derim.

//Burada yeni bir komut görüyouz;şuana kadar  bir action ın bittikten sonra hep viewle sonlanmasını sağladık.=)bir view çalışsın ki html render etsin isteyen kişi client tarafında  bunu (viewi)yollasın diye ama şimdi keydetme işlemi gerçekleşir gerçekleşmez beni Psikologlar sayfasına yönlendirsin istiyorum.Ve yeni girilen kişi sayfa da gösterilsin de isterim yani beni Trainercontroller de ındex actionum yeniden çalışsın istiyorumki yeniden gitsin veri tabanın dan verileri çeksin ve tekrar ana sayfa viewimi göstersin.Oyüzden artık view demek yerine benim Index actinumu tetiklemem gerek.
//Return dan sora bunu yapabilmem için özelbir fonksiyon/methot  vemiş=)RedirectToaction(tekarra şu actionu yönlen)akışı şu action a yönlendir.
//Edit kısmından sonra not tutmaya devam edersin sonra!