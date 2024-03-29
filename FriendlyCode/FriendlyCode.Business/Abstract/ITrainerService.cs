using FriendlyCode.Core.ViewModels;
using FriendlyCode.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Business.Abstract
{
    public interface ITrainerService
    {
        List<TrainerViewModel> GetAll(bool? isHome =null,bool? isActive = null,bool? isDelete = null);//Parantez içine 3 tane parametre koyduk,ayrı ayrı yazmamak için;Bu methot imzam nasıl bir methot oluşturmak için hazırladığım imza oldu=  geriye TrainerVewModel tipinde değerler taşıyan bir liste döndürecek bir methot hazırlamış oldum.R işemi yaptık>liste halinde okuma yapıp getircek
        //1)İd'si şu olan Trainer ı getir;ürünler listelenmiş kullanıcıya tıklayınca onun detay bilgilerini göstericeğimiz durumda lazım olacak o zaman geriye ne döndürecek?=TrainerViewModel döndürecek ismi da = GetById içine de=int id alsın=)R işlemi>=veri tababından tek bir ürünü okuyup getireck
        TrainerViewModel GetById(int id);
        //2)Cread =)yeni bir kayıt oluşturuken;kullanıcıya viewModel tipinde birşey girdirip o grileni buraya göndericez kaydetme sonun da da birşey döndürmeyeceğiz demek ki methodumuz birşey döndürmeyecek(void) adına=Create parantea içine de dışarıdan TrainerViewModeltipinde bir veri gelicek ,adı da= model olan=)
        void Create(TrainerViewModel model);
        //3)Update işlemi;o da geriye birşey döndürmesin(void)adı Update ,tipi trainerviewmodel olan yine model gelsin;niye kullanıcı birşeyleri değiştireceği bir twm ı buraya gönderir ben de veri tabanında ki o ilgili trainerla eşleşmesini sağlarım.
        void Update(TrainerViewModel model);
        //4)Delete=)2 tane olsun(isDelate yaptık ya)HardDelete=normal veri tabanın dan silme ilgili kaydı göndermeye gerek yok sadece id sini göndermemiz yeterli;(niye int tanımladım benim trainerlarımın id si int)
        void HardDelete(int id);
        //SoftDelete=)Geri dönüşümlü isDelete i kullanarak silmek için.basit bir update işlemi aslında;
        void SoftDelete(int id);
    }
}
//public olsun,internal olursa sadece bulunduğu projenin içinde her yerde çalışır.public heryerden çağırabileceğim.
//Burada CRUD işlemlerini gerekleştirecek methot imzalarını yazacağımız yer.(Trainerlar için)7
//Bu(yazıcağımız methot) bize ne döndürsün?= bir TrainerListesi döndürsün tip olarak.*(?=null da olabilir,bool tipde bir değişkenin içine normalde 2 değeri verebiliyoruz;true ya da false)
//interface olduğu için gövdesi yok;bundan miras alarak oluşturacağım classta yazıcam.
//Businessta bazı işler yapmamız lazım;Mvc katmanı son kullanıcıya açık arayüzümüz,entity de olanları sadec veri tabanıyla ilgili işleimde kullanılacak şeyler.Mvc katmanımda da entitylerimden kullanıcam ama o zaman oraya özel başka bir class hazırlıyorum=ViewModel viewlwrw gönderirken kullanıcıya bunları gösterirken kullanacığımı model oluyordu.
//Mvc katmanımda Models içine Viewmodel diye bir class oluşturuyoruz.(Apide view yok DTO var veriyi sadece taşımak amacı)
//Read için iki tane işlem yaptık )1i birini getirebilsin=Creta;2.GetAll tümünü getirebilmesi için
//Silmek için 2 tane methot yazdık.
//CRUD tümü için lazım;Interface de yazma amacımz;her enitiy için lazım olabiliecek şeyler olduğu için



////Program cs e giderek AddDbContext için yaptığımız benzer şeyi bu repositorylerimiz için yapalım (soyutlamayı bir ileri seviyeye taşıyıp uygulama içinde herhangi bir yerde ITrainerRepository tipinde birşey istiycem yeni bir nesne mesela ya da öyle bir değişken tanımlıycam oysa biliyoruz ki interfaceleri bir tip olarak tanımlayamayız ama soyutlama için)ITrainerService diyeyim sana sen TrainerRepository anla demeyi sağlamak için gideriz.Niye=Bir interface den nesne oluşturduğumu anlayacak,somutumu aklayıp soyutlamış olucam yani.(ITrainerService den bir nesne oluşturduğumu görücek koduma bakan kişi)somutların esnek hale gelmesini sağlamış olucam;ITrainerService i başka bir reposireyde de implemente edip dupperle iş yapabilirim mesela,ITrainerService başka bir Repository e implemente edip orda da Oracle ile iş yapabilirim(bambaşka veri tabanlarıyla)