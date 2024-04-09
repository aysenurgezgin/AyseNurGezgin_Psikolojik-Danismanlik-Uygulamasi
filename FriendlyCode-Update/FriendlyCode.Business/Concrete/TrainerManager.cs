using FriendlyCode.Business.Abstract;
using FriendlyCode.Core.ViewModels;
using FriendlyCode.Data.Abstract;
using FriendlyCode.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Business.Concrete
{
    public class TrainerManager : ITrainerService
    {
        private ITrainerRepository _trainerRepository;

        public TrainerManager(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public void Create(TrainerViewModel model)
        {
            throw new NotImplementedException();
        }

        public List<TrainerViewModel> GetAll(bool? isHome=null, bool? isActive=null, bool? isDelete = null)
        {
            var trainers = _trainerRepository.GetAll();
            List<TrainerViewModel> trainerViewModels = new List<TrainerViewModel>();
            TrainerViewModel trainerViewModel;
            foreach (var trainer in trainers)
            {
                trainerViewModel = new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Price = trainer.Price,
                    ImageUrl= trainer.ImageUrl,
                    Properties = trainer.Properties,
                    Url = trainer.Url
                };
                trainerViewModels.Add(trainerViewModel);
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

//*Manager service ten bahsediyorsak;Bussiness katmanı.
//*Repositorylerden bahsediyorsak;Data katmanı.
//=)Bu Generic Repository Dizayn Patterni kullanırken bu kullnacağımız birşey çünkü

//Get All methodunda data katmanındaki TrainerRepository in içinde aşağıda gözükmeyen ama GnericRepositoryden buraya aldığım GettAllı buraya çağırmaya çalışıyorum.OZaman GenericRepositoryden bana bir nesne gerekiyor.(OOP gereği;bu classtan bir nesne üreticem ki ben aşağıda ki methotları kullanabileyim.)işte biz burda new dememek için;Program cs'te skoplarımızı ekledik addScoped diyerek o zaman ben bu classın içinde o Conteyner'a koymuş old. TrainerRepository'i almam gerekiyor.Ben orada ITrainerRepository tipinde brşey istiycem ama o bana TrainerRepository'i verecek.;Normalde böyle bir tanımlamayı yapamayız çünkü bu Interface(tip olarakak kullanılamaz normalde)ama Program cs te yazmış old. AddScoped kodu ne sağlıyor?=)Sanki ben burada ITrainerRepository den bir nesne oluşturuyormuşum gibi davranabiliyorum.Aslında şu bana verd. _trainerRepository hangi tipte bir nesne oldu?=TrainerRepository tipinde bir nesne oldu.Ve bunn ctor unu yazıcaz.Dependencs Enjection yapıcaz buraya o Conteyner daki TrainerRepository nesnesini alıp buraya enjekte edicez,Vs studio da da VsCode da da bunun ctorunu bizim için kendisinin oluş.komut var; bulunulan satırda herhangi bir yere tıklayıp çıkan ampüle basıp(ctrl+nokta ile de çıkarabilirz.)bir komut var= Generate  constructor 'TrainerManager(ITrainerRepository trainerRepository)'onu seç ve bir constructor methot oluşturmasını sağla.Dışarıda ki ITrainerRepository tipinde ki trainerRepository'i aldı bizim dışarıda ki tanımladığımız şeyin içine koydu.Bunu yapmamızın ilk sebebi new deyip tekrar yazmak bellekte gereksiz birsürü değişken oluşturuyor .İkincsi aslında bu bir SOLID(prensibinin) ilkesinin yansıması.//Bağımlılığın tersine çevirilmesi ilkesidir bu dependecy enjection yöntemi ile.

//Artık ben trainerRepository nesnesine sahipsem TrainerRepository içindeki GetTreanerByCategoryId nesnesini kullanabilirm.+ ben buraya miras aldığım GenericRepository 'deki 6 methodu da kullanabilirm.Onlarında 5'inin içi boştu biz birtek GetAllu yazdık yani artık GetAll'u kullanabilirm.Nerde? burada.Tabi ki geriye ne döndürüyor?=Bizim GEnericRepository'de yazdığımız ne döndürüyordu=)List<TEntity>,biz ne için miras aldık;trainer için ozaamn =)List<Trainer>döndürecek.(gerekli namespace'i seçtiğine emin ol=FriendlyCode.Entity olacak)ismi trainer=(*nerden çekicem ben bu veriyi)_trainerRepository'deki .GetAll();dan(*.dedikten sontra tüm methotları görebiliyruz.)
//Mesela . dan sonra Create deyip parantez açınca ne istiyor?=)<Trainer>niye;çnkü TrainerRepository'e miras alınırken ben bunu<Trainer>'ı kullanarak aldım yani bunun içinde(aşağıda)var olan fakat gözükmeyen Create aslında içinde Trainer istiyor.Burada var olan ama gözükmeyen GetAll aslında List<Trainer>döndürüyor.Yani TEnitity görd. her yerde şuan Trainer var şuan burda ki methotlarda

//Burada artık bir değişken tanımladık(trainers)isminde bir nesne;biliyoruz ki bir değişken tanımlarken tip veririz (List<Trainer>)C#'ın temel kuralı.Fakat artık bazı noktalarda daha kolay kod yazmak için kimi zaman gereksiz namaspace ler eklememek için şuan da burda hepsi yok;biz tarz durumlar için çoğu kez VAR keeyword'ünü kullanırız.Var=)Şuan da yazmış old. satırda ne anlıyoruz?=GetAll ne tipte birşey döndürüyor;List<Trainer> dolayısıyla benim şunu(_trainerRepository.GetAll();)aktaracağım değişkenin tipi ne olmalıymış;List<Trainer> ben de zaten ona göre yazmışım.Ama List<Trainer>'ı silip yerine Var yazdığım zaman bana bir hata vermediğini görürüm.=)sen burda JS gibi davran demiş olduk.Js ne yapıyordu;bir değişkenin içine hangi tipte değerde atarsaak onu o tipte yapıyordu.
//Şuan benim elimde ne var=)List<Trainer>tipinde bir liste var Trainers diye peki benim geriye döndürmem gereken(bu methodun geriye dönd.gereken)şeyin tipi;TrainerViewModel tipinde ki Listeyiymiş.O zaman benim trainers ı alıp TrainerViewModel tipine döndürmem gerekiyor.;Mvc'ye biz trainer'la ilgili birşey göndermiycez,orda ViewModel'la çalışıcaz diye.Dolayısıyla ben geriye List<TrainersViewModel>tipinde bir değişken oluştur diycez(var da yazabilirdik tabi ki)adına da trainerViewModels=new List<TrainersViewModel>();derim new deyince de boş bir tane oluştmuş olurum oysa;trainers'a öyle birşey yaıcam ki tek tek bunun içinde dolaşıcam içindeki tüm trainerları alıp TrainersViewModel tipinde nesneler oluşturucam.Şu oluşsunList<TrainersViewModel> ve ben trainers içinde döneyim.(Kullanmayacağımız bir teknik anlamk için döngü mantığını)

//foreacf;Trainerların içinde dolaşıcam her sıradaki elemena da trainer diyorum.Kendi hazırladığımız classlar arasında yapıyoruz,trainerViewModel classımız ,trainer classımız var elimize gelen şey trainerListesi,ben TrianerViewModel Lİstesi yapmak istiyorum.Her bir tariner için bana(dışarı da TrianerViewModel tipinde tranerViewModel oluşturalım başlangıçta herhangi bir değer vermeyelim)foreach döngüsü içiçnde yaptığım şey;döngünün içine ilk gird zaman yeni bir trianerViewModel tipinde nesne oluşturup 1.trainerın özelliklerini bunun içine koymuş oldum.Bu biterbitmez döngünün içindeyken Yukarıda oluşt.listeye bunu ekliyorum;1.Trainerımı TrianerViewModel tipine dönüştürüp listeye ekledim.Döngü dönünce sırayla devam edecek.Bu bittiğinde de içinde trianerViewModel tipinde değerler taşıyan bir trianerViewModels listesi olucak ve bunu return edebilirim.
//Peki buna ne zman iht duymuştuk ve bunu yazmıştık?Mvc de Home'un indexinin içinde çağıracak bir methot bulamamıştık bussiness katmanın da o yüzden bunu yazmıştık(Mvc ye dön Home controllerıa)

//?
//AppDbContext lazım o repository e birşey söylemem gerkiyor.Yine bir ctor yazıcam;bu TrainerRepostory den nesne üretildiğinde (burda da her zaman, her lazım old. new deyip üretilmesini istemiycez)onu da Program cste oluşturucaz.bir kere new yapıldığında buraya AppDbContext tipinde ismi appDbContext olablilir gelen GenericRepository e gitmesi gerekiyor da alıcak nasıl?=base e gönderek.Base artık GenericRepository(Base classı temsil eden kavram ve bir class tek bir classtan miras alabilir,classıda başa yazmak gerekiyrdu.)(*Set ancak DbContext üzerinde çalışabilen birşey)(*AppDbContext DbContext ten miras alarak oluşmuştu,onun bütün özlklerine sahipti.)
//Benim bu Context ti kullanmam gerekiyor burada.ITrinerRepositorye gitt.
//*GetHomePagesTrainerın methot imzasını implement interface edrek buraya almış oluyorum.
