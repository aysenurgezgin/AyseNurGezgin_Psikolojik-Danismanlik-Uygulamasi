using FriendlyCode.Business.Abstract;
using FriendlyCode.Core.ViewModels;
using FriendlyCode.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Business.Concrete
{
    public class TrainerManager : ITrainerService
    {
        private  ITrainerRepository _trainerRepository;

        public TrainerManager(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public void Create(TrainerViewModel model)
        {
            throw new NotImplementedException();
        }

        public List<TrainerViewModel> GetAll(bool? isHome = null, bool? isActive=null, bool? isDelete = null)
        {
           var trainers =_trainerRepository.GetAll();
            List<TrainerViewModel> trainerViewModels = new List<TrainerViewModel>();
            TrainerViewModel trainerViewModel;
            foreach (var trainer in trainers) 
            {
                if (trainer.IsHome == isHome)
                {
                    trainerViewModel = new TrainerViewModel
                    {
                        Id=trainer.Id,
                        Name=trainer.Name,
                        Price=trainer.Price,
                        ImageUrl=trainer.ImageUrl,
                        Properties=trainer.Properties,
                        Url=trainer.Url
                    };
                    trainerViewModels.Add(trainerViewModel);
                }

            }
            return trainerViewModels;
        }
       
        public TrainerViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TrainerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
//bu bir class ama Bunun içinde Abstartct içindeki methotların dolu halini istiyorum o yüzden miras almalıyım;interface espirisi bu bir kontrat ,kontratın mmaddelerini kabul ettğini söylemek için (implemente)yaparız.(dolu halini yazmak basitçe)


//  public List<TrainerViewModel> GetAll(bool? isHome, bool? isActive, bool? isDelete)
//{
//    throw new NotImplementedException();
//}
//kısmı için açıklama;
 //Getall amacı=Data katmanına gidip bana şuanlrı getir demekti yok ama confifg var sadece (veri tabanı oluşurken gerekli şeyler)orada Trainerların istediğimiz kritere uygun olanlarının veritabanından çekilmesini sağlayan ki veri tabanında trainer tipinde döndürecek herhangi bir liste methot yazmadık;yazınca buraya (süslü parantez içine)burda onu çağırıcaz.o da bize trainer tipinde değerler taşıyan bir liste getirecek biz onu alıp TrainerViewModel tipinde değerler taşıyan bir listeye dönüştürüp Mvc katmanına geri döndürücez.