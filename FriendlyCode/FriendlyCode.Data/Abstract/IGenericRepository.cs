using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        //Temel veri tabanı işlemlerimizi barındıracağız(CRUD)

        //Geriye bir liste döndürücem GetAll için fkat tipi TEntity olacak adı da GetAll olabilir;
        List<TEntity> GetAll();//R
        //Tek bir Trainer ya da catogoryi dndürmek üzere GetById diye bir methot kullanamak istiyorum ;geriye TEntiy döndürecek adı da GetById olsun ve dışarıdan id parametresini alsın;
        TEntity GetById(int id);//R
        //Geriye herhangi birşey döndürmeyi planlamadığımız adının Create olacağı fakat burada araya gerçek entityler girecek(view model yok burada)TEntity artık buarada Trainer ya da Category olacak ismi de entity olsun;
        void Create(TEntity entity);//C
        void Update(TEntity entity);//U
        void HardDelete(TEntity entity);//D
        void SoftDelete(TEntity entity);//D
    }
}


//Generic yapıyı kullanmam gerekiyor.Business katmanımda Trainerları listelemekle Categoryleri listeleme işlemleri arasında farklı şeyler yapıyor olabilirim ama Data katmanıma geldiğim zaman veri tabanımdan istekte bulunacağımız tablo dışında her şey mantık olarak aynı olacak(git Trainerları getir,git müşterileri al getir)Dolayısıyla yazacağımız temel CRUD işlemlerini yapmaya yarayacak olan methotlarımız aslında neredeyse bütün entitylerimiz için ortak çalışma ihtiyacına sahipler.Bu sebeble(genellikle)temel bir yapı kurar ve bu temel yapının diğer tüm entityler için aynı olmasını sağlarız bunu da hem abstarcktion mantığını kullanrak hem de generic yani(generic diyince List yapısı gelsin aklına)List deyip köşeli parantez için de hangi tip bir değer taşıyacağımızı söylüyorduk.Kendin bir class yazdın fakat bu class içerisine bir tip alması gerekiyor(içerde tiple iş yapıcak)

//new item deyip Interface i seçip ismine de IGenericRepository=)sadece Trainer için değil sadece Category için değil tümü için geçerli olacak CRUD işlemlerinin methot imzalarını barındıracak.Repository olmas sebebi=)burası birnevi veri depomuz,veriler burada çekiliyor,veriyle ilgili herşey burada yapılıyor ayrıca ouşturduğumuz mimari desenin ismini veren kavramda o.(Şuan da oluşturmaya başladığımız mimari tasarımın adıda GenericRepositoryDizaynPattern)

//Bunu Generic olarka oluşturmanın yolu nasıl;onu nasıl gerçekleştiriyoruz?=)Normalde bunu(IGenerigRepository)herhangi bir yerde miras olarka verdiğimde iki nokta IGenericRepository den miras al derim.Fakat şimdi örn.başka bir class oluşturdum ve bunu miras alacaksam IGenericRepository'den miras al ama bunu Trainer için;Category için miras al diyeceğim.İşte bunu da on göre ayarlamam gerek.Tek yapmam gerekn;<>EntityFrameworkCorunda,.netinde önerdiği 2 tane isim öneriliyor genelde Type tip vericez ya buraya ;Category tipi trainer tipi vs dışarıdan göndericez ya onu karşılayacak sanki bir parametre yazıcaz,sanki bir fonksiyonun dışarıdan methodun gönderecek parametresi.Ya type ın T si ya da entfcorela çalışıyoruz ya bunlar bizim için aynı zaman da Trainer, Category =entity ya, ya da TEntity deriz bu bir değişken ismi=)dışarıdan gelecek buraya verilecek tipin adını bunun içinde tutacak

//Normal fonkisyonlarda parametre gönderir gibi düşün şimdilik.

//Bu imzalarınızı attığımıza göre bundan biryerler de miras alarak yeni classlar oluşturabilirm.

//Trainerlala ilgili işlemler yaparken bundan miras alıp Trainer için 6 tane methodu oluşturucam hakeza Categoryler için de .Peki Tainer için Category de kullanmayacağım özel bişeye ihtiyac duyarsam=onu da soyutlamayı tercih ediyoruz;IGenericRpository dışında ITrainerReposiyory diye bir tane daha Interface daha yapıcam ordda da sadece trainerı ilgilendirenler olacak.

////Program cs e giderek AddDbContext için yaptığımız benzer şeyi bu repositorylerimiz için yapalım (soyutlamayı bir ileri seviyeye taşıyıp uygulama içinde herhangi bir yerde ITrainerRepository tipinde birşey istiycem yeni bir nesne mesela ya da öyle bir değişken tanımlıycam oysa biliyoruz ki interfaceleri bir tip olarak tanımlayamayız ama soyutlama için)ITrainerService diyeyim sana sen TrainerRepository anla demeyi sağlamak için gideriz.Niye=Bir interface den nesne oluşturduğumu anlayacak,somutumu aklayıp soyutlamış olucam yani.(ITrainerService den bir nesne oluşturduğumu görücek koduma bakan kişi)somutların esnek hale gelmesini sağlamış olucam;ITrainerService i başka bir reposireyde de implemente edip dupperle iş yapabilirim mesela,ITrainerService başka bir Repository e implemente edip orda da Oracle ile iş yapabilirim(bambaşka veri tabanlarıyla)
///
///**/Program cs e giderek AddDbContext için yaptığımız benzer şeyi bu repositorylerimiz için yapalım (soyutlamayı bir ileri seviyeye taşıyıp uygulama içinde herhangi bir yerde ITrainerRepository tipinde birşey istiycem yeni bir nesne mesela ya da öyle bir değişken tanımlıycam oysa biliyoruz ki interfaceleri bir tip olarak tanımlayamayız ama soyutlama için)ITrainerService diyeyim sana sen TrainerRepository anla demeyi sağlamak için gideriz.Niye=Bir interface den nesne oluşturduğumu anlayacak,somutumu aklayıp soyutlamış olucam yani.(ITrainerService den bir nesne oluşturduğumu görücek koduma bakan kişi)somutların esnek hale gelmesini sağlamış olucam;ITrainerService i başka bir reposireyde de implemente edip dupperle iş yapabilirim mesela,ITrainerService başka bir Repository e implemente edip orda da Oracle ile iş yapabilirim(bambaşka veri tabanlarıyla)