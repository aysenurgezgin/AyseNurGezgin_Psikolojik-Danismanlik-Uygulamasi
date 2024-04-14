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
            var trainer = new Trainer
            {
                Name = model.Name,
                Price = model.Price,
                Properties = model.Properties,
                Url = model.Url,
                ImageUrl = model.ImageUrl,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IsHome = model.IsHome

            };
            _trainerRepository.Create(trainer);
        }

        public List<TrainerViewModel> GetAll(bool? isHome=null, bool? isActive=null, bool? isDelete = null)
        {
            List<Trainer> trainers;
      //İçine hiçbirşey gelmemişse;
           if (isHome == null)
            {
              trainers = _trainerRepository.GetAll();
            } 
          else 
            {
                trainers = _trainerRepository.GetHomePageTrainers(isHome);
            }
            List<TrainerViewModel> trainerViewModels = trainers
                .Select(t => new TrainerViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    Url = t.Url,
                    ImageUrl = t.ImageUrl,
                    Properties = t.Properties
                }).ToList();
            return trainerViewModels;
        }
       
        public TrainerViewModel GetById(int id)
        {
           Trainer trainer = _trainerRepository.GetById(id);
            TrainerViewModel trainerViewModel = new TrainerViewModel
            {
                 Id =trainer.Id,
                 Name = trainer.Name,
                 Price = trainer.Price,
                 Url = trainer.Url,
                 ImageUrl = trainer.ImageUrl,
                 Properties = trainer.Properties
            };
            return trainerViewModel;
        }
        //_trainerRepository methot sayesinde trainerlar içinde ilgili id li trainer gldi ama tipi Trainer ben TrainerViewModel döndürmeliyim.(nesneye çevirme işlemi)Artık bunu Mvsc yapımın içinde ki Controller daki action da çağırabilirm.
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
           Trainer editedtrainer =_trainerRepository.GetById(model.Id);
            editedtrainer.Name = model.Name;
            editedtrainer.Price = model.Price;
            editedtrainer.Url = model.Url;
            editedtrainer.ImageUrl = model.ImageUrl;
            editedtrainer.Properties = model.Properties;
            editedtrainer.IsHome= model.IsHome;
            _trainerRepository.Update(editedtrainer);
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

//*Var ın çalışma mantığında;tipini ancak içine birşey atarsam tanımlayabilir.C#'ta da tipini belirlemeden değişken tanımlayamaz.;O zaman List<Trainer>(tipini belirterek yazmak gerek yani)

//*Koşula bağlı yaazım başlıyor GetAll da

//List<TrainerViewModel> trainerViewModels = new List<TrainerViewModel>();
//TrainerViewModel trainerViewModel;
//foreach (var trainer in trainers)
//{
//    trainerViewModel = new TrainerViewModel
//    {
//        Id = trainer.Id,
//        Name = trainer.Name,
//        Price = trainer.Price,
//        ImageUrl= trainer.ImageUrl,
//        Properties = trainer.Properties,
//        Url = trainer.Url
//    };
//    trainerViewModels.Add(trainerViewModel);
//}  //*uzun olan yapı

//*Şimdi daha idealini yazıyoruz.Trainerları alıp TrainerViewModel olarak vermek amacımız.ki aldık Trainerları elimizde (List<Trainer>trainers yazdığımız kısım)bana TrainerViewModel tipide bir liste ver adı da trainerViewModel olsun = de ve trainerlar içinde dön Select ile her bir trainer için yeni bir TrainerViewModel oluştur diyecek ve ne dediği için Skopummu açıp({})ViewModel tipindeki değişkenimin değerlerini girmeye başlıyacağım.Sonunda .ToList(); yazıcaz ki kızgın olmasın nende dedik=List<Trainer>trainers içine değer aktarmaya çalıştd için.Trainer içinde kaç tane trainer varsa o kadar new deyip tekrarlayacak.

//*GetById için= Bunu çağırıcaz Mvc projemizdeki Action içinden


//Data katmanım da Create ile ilgili yazdım.Yapıcağımız şey Cretae Mvc den çağırılacak Mvc de bir TrainerViewModel tipinde değer göndercek oysa data da ayarladığımız create ise TEntity tipin de yani trainer  ya da category tipin de yani ben bunun burda dönüştürmem gerekiyr.ve bunları içine ek tek alma ilemine başlıyorum.Veri tabanına gönderiyorum önce Id si olmaz bu kaydın Id bizim için;kayıt olurken oluşturulan birşeydi.Yeni kayıt da ıdli ilgili hiçbirşekilde muhattab olmuyoruz.Modelden gelen den NAme yani trainerın name i .Kullanıcı TrainerViewModel bunun içinde formda ne girmiş se o buraya gelicek.Bu işlem tamamsa; gelen TrainerViewModelı Trainerı dönüştürdüm artık ben Trainer ı _trainerRaository imde ki Create methoduma gönderebilirm.Burda Create i çağırdım işini yaptı  ve ne oldu çağırdığım yere döndecektir;Mvc de Area ya gidip Admin Controllersa gidip Trainer Controlllera gidip Crate diye bir methoda ihtiyacım var ve nu orada ekliycem.
