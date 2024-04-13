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
    }
}

//Bir area ile çalıştığımız zaman unutmamamna gereken Areayı classın üstüne hemen eklemek.
//Şuan da Prikologlara(trainerlara)ulaşmak istediğimiz için Business katmanına erişmem gerekiyor.Manager deki GetAll'u  çağırmalıyım.;O zaman o manager den bana bir nesne lazım Ve bunu da ctor vasıtasıyla alıyorduk buna da dependency enjection yöntemi deniyordu.;Artık elimde _trainerManager diye bir değişken var ve bu değişken saayesin de trainerManagerde ki methotları çağırabilir kullanabilirm.ve view e gidip modeli de eklemem gerekiyor.Buraya da TrainerViewModel Listesi gelicek (Business katmanımda ki GetAll methodu böyle bir Liste döndürdüğü için)