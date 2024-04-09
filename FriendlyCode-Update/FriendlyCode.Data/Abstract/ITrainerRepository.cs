using FriendlyCode.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Abstract
{
    public interface ITrainerRepository:IGenericRepository<Trainer>
    {
        //Trainer'a özgü methot imzalarımızı buraya yazacağız.
        List<Trainer>GetTrainersByCategoryId(int categoryId);
        List<Trainer> GetHomePageTrainers();
    }
}
//Bu içinde ıGenericRepository içinde ki methotları barındırmalı ama Trainerlarla ilgili işler yapıcam fakat IGnericRepository Gneric yazılmış yani genel olarak yazılmış bişey ama IGenericRepository sen bana TEntiy verirsen ben ona göre yapılandırıcam deme imkanı veriyordu o zamn bnde<>içine Triner için hazırla derim.(Bir inreface e başka bir interfcace den miras aldırırsak implemente edecek birşey olmaz çünkü burda da kod yok)classtan class a  miraz almış gibiyim.(Orda ne varsa buaraya da o özellikleri eklemiş oluruz)IGenericRepository içinde ne varsa bunun içinde de o var.Fakat Trainer için olnaları var artık.

////Program cs e giderek AddDbContext için yaptığımız benzer şeyi bu repositorylerimiz için yapalım (soyutlamayı bir ileri seviyeye taşıyıp uygulama içinde herhangi bir yerde ITrainerRepository tipinde birşey istiycem yeni bir nesne mesela ya da öyle bir değişken tanımlıycam oysa biliyoruz ki interfaceleri bir tip olarak tanımlayamayız ama soyutlama için)ITrainerService diyeyim sana sen TrainerRepository anla demeyi sağlamak için gideriz.Niye=Bir interface den nesne oluşturduğumu anlayacak,somutumu aklayıp soyutlamış olucam yani.(ITrainerService den bir nesne oluşturduğumu görücek koduma bakan kişi)somutların esnek hale gelmesini sağlamış olucam;ITrainerService i başka bir reposireyde de implemente edip dupperle iş yapabilirim mesela,ITrainerService başka bir Repository e implemente edip orda da Oracle ile iş yapabilirim(bambaşka veri tabanlarıyla)

//*Ana sayfa ürünlerini çekmeye yarayacak methodunun imzasını atmak için buraya geldim.Amacım veri tabanını,uyglamamı çok yormadan iş yapmak.(İşime yaramayacak dataları boşuna veri tabanın dan çekmemiş olmak için yapıyoruz.)Somutunu yazmak üzere de Data katmanımda yine Conrete te TrainerRepository'e geçiyorum.
//?

//AppDbContext lazım o repository e birşey söylemem gerkiyor.Yine bir ctor yazıcam;bu TrainerRepostory den nesne üretildiğinde (burda da her zaman, her lazım old. new deyip üretilmesini istemiycez)onu da Program cste oluşturucaz.bir kere new yapıldığında buraya AppDbContext tipinde ismi appDbContext olablilir gelen GenericRepository e gitmesi gerekiyor da alıcak nasıl?=base e gönderek.Base artık GenericRepository(Base classı temsil eden kavram ve bir class tek bir classtan miras alabilir,classıda başa yazmak gerekiyrdu.)(*Set ancak DbContext üzerinde çalışabilen birşey)(*AppDbContext DbContext ten miras alarak oluşmuştu,onun bütün özlklerine sahipti.)
//Benim bu Context ti kullanmam gerekiyor burada.ITrinerRepositorye gitt.
//*GetHomePagesTrainerın methot imzasını implement interface edrek buraya almış oluyorum.V
