using FriendlyCode.Data.Abstract;
using FriendlyCode.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Concrete
{
    public class TrainerRepository:GenericRepository<Trainer>,ITrainerRepository
    {
        public TrainerRepository(AppDbContext _appDbContext):base(_appDbContext)
        {
            
        }
         AppDbContext AppContext {
            get 
            {
                return _dbContext as AppDbContext;
            }
        }//Seti olmayacak salt okunabilir bir propert olucak ve get inde de özel bir kod yazıcaz.(burda kullanacağımız için public demeye gerek yok){}parantez içine bu AppContext çağırıldığı yerden GnericRepository de ki _dbContexti geri döndür.

        public List<Trainer> GetHomePageTrainers(bool? isHome)
        {
            //LINQ=Language Interface Query
            var trainers = AppContext
                .Trainers
                .Where(t => t.IsHome==isHome && t.IsActive && !t.IsDelete)
                .ToList();
            return trainers;
        }
        //*Dışarıdan isHome için true gönderilmişse;true olnalrı false ise false olanlarını göster demiş olurum.Bunun sayesinde TrainerManager deki fazla if yapıarına gerek kalmaz.Daha basiti yetecek.Orada null yaptıysak tabi burda da null yapmalıyım;gererige de gidipbool yanına ? ekleyince hata girerilir.


        //Bu sayede Context imizin içinde yer alan bütün dbsetlerimize erişebiliyoruz onlar sayesinde de tablolarımıza erişebiliyoruz.
        public List<Trainer> GetTrainersByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
//Burda iht duyduğum 6 tane temel CRUD işlemlerimi yapan methotlarımın somut halleri GenericRepository deydi bunu öncelikle o classtan Trainer için miras almalıyım.
//Trainera özgü yazdıklarımın da buaraya gelmesini istiyorum kullanmam için.<Trainer>yanına (,)deyip(birden fazla classtan miras alamıyoruk ama inteface den alabiliyorduk)ITrainerRepository derim.
//AppDbContext lazım o repository e birşey söylemem gerkiyor.Yine bir ctor yazıcam;bu TrainerRepostory den nesne üretildiğinde (burda da her zaman, her lazım old. new deyip üretilmesini istemiycez)onu da Program cste oluşturucaz.bir kere new yapıldığında buraya AppDbContext tipinde ismi appDbContext olablilir gelen GenericRepository e gitmesi gerekiyor da alıcak nasıl?=base e gönderek.Base artık GenericRepository(Base classı temsil eden kavram ve bir class tek bir classtan miras alabilir,classıda başa yazmak gerekiyrdu.)(*Set ancak DbContext üzerinde çalışabilen birşey)(*AppDbContext DbContext ten miras alarak oluşmuştu,onun bütün özlklerine sahipti.)
//Benim bu Context ti kullanmam gerekiyor burada.ITrinerRepositorye gitt.
//*GetHomePagesTrainerın methot imzasını implement interface edrek buraya almış oluyorum.(Var)Tipini kendi belirleycek şelikde Trainerları getirmek istiyorm.Veri tanımla iligi bütün varlıkları eişmemi sağlayan yapımın ismi:AppContext(Trainer tablosuna erişim yani)Sql sorgusu yazmamıza gerek kalmadan(Set TEntity )Entity FraemWorkCore'un olş sağlayan Linq sorgularını kullanıyor oluruz.Select*Trainer Tabi Aktif olanlar ve silinmemş (Where)Lamda ifd kullnaıyoruz ne düşüncez=Mesala burda trinerlarla uğraşıyorum tüm trainerlara tek tek bunu uygula dememi sağlıyan dönme işlemi sağlıyor.Her trainer'a vermek istd isim;birden fazla old için hangisi old anlamak için bir harfi anlamlı vermek gerek karşmaması içn(!t değilini almak anlamına gelir.).Tolİstlee.//Trainerları getir şunlara uygun olanları listele.Bu yazd koda .Net'in bize sunduğu LINQ sorguları tekniği denir.Sorgular için ortak bir anadil(Sqlite,SqlServer,Mongoda da aynı şekilde bu kodlar çalışır eğer Entirty Freamwork Core'la eğer Mongo'ya erişiyorsam.)=Kullanılan veri tabanın iht duyduğu sorgu neyse yazd onu olşturacak.Bu kolaylıkta Entirty Freamwork Core'u kullanma gerekçelrimizden biri.(Güvenlik perfons  gibi fayd var.)Bu verilen trainerları da geri döndürelim Return ile.

//*yeni bir parametre eklediğimde methoduma abstracta;  bunu tekara implemente etmemeliyim.Concrete de kızmasının sebebi ilk yazdığımız da interfacde ki parametre yoktu parametre ekledik;değişti diye.Implemente yaprsam yeni bir bir methot yazar:Ama bn GetHomePageTrainers()içine de (bool isHome)yazarım ve kızgınlık geçer.
