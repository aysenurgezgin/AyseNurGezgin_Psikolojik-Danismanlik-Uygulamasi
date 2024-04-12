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

        public List<Trainer> GetHomePageTrainers()
        {
            var trainers = AppContext
                .Trainers
                .Where
        }

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
//*GetHomePagesTrainerın methot imzasını implement interface edrek buraya almış oluyorum.(Var)Tipini kendi belirleycek şelikde Trainerları getirmek istiyorm.Veri tanımla iligi bütün varlıkları eişmemi sağlayan yapımın ismi:AppContext(Trainer tablosuna erişim yani)Sql sorgusu yazmamıza gerek kalmadan(Set TEntity )Entity FraemWorkCore'un olş sağlayan Linq sorgularını kullanıyor oluruz.Select*Trainer Tabi Aktif olanlar ve silinmemş (Where)
