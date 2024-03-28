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
        public TrainerRepository(AppDbContext appDbContext):base(appDbContext)
        {
            
        }
        public AppDbContext  { get; set; }

        public List<Trainer> GetTrainersByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
//Burda iht duyduğum 6 tane temel CRUD işlemlerimi yapan methotlarımın somut halleri GenericRepository deydi bunu öncelikle o classtan Trainer için miras almalıyım.
//Trainera özgü yazdıklarımın da buaraya gelmesini istiyorum kullanmam için.<Trainer>yanına ,deyip(birden fazla classtan miras alamıyoruk ama inteface den alabiliyorduk)ITrainerRepository derim.
//AppDbContext lazım o repository e birşey söylemem gerkiyor.Yine bir ctor yazıcam;bu TrainerRepostory den nesne üretildiğinde (burda da her zaman her lazım old. new deyip üretilmesini istemiycez)onu da Program cste oluşturucaz.bir kere new yapıldığında buraya AppDbContext tipinde ismi appDbContext olablilir gelen GenericRepository e gitmesi gerekiyoro da alıcak nasıl?=base e gönderek.Base artık GenericRepository(Base classı temsil eden kavram ve bir class tek bir classtan miras alabilir,classıda başa yazmak gerekiyrdu.)(*Set ancak DbContext üzerinde çalışabilen birşey)(*AppDbContext DbContext ten miras alarak oluşmuştu,onun bütün özlklerine sahipti.)
//Benim bu Context ti kullanmam gerekiyor burada.ITrinerRepositorye gitt.