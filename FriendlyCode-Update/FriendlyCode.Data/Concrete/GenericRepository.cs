using FriendlyCode.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;//bulunduğum yerden erişebilmemiz için protected yaptık(public business ttan da Core dan da kullanılabilir ama bana bu gerekmiyor)
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> entities = _dbContext.Set<TEntity>().ToList();
            return entities;
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
//Generic bir class oluşturduk;hepsi için ayrı ayrı bunların kodunu yazmak istemiyorum =TEntiy yardımcı olacak.
//Bu da generic o yüzden bu da dışarıdan gelecek bir tipe ihtiyacı var;ayrıca IGenericRepositoryi implemente etmesi gerek(o 6 methodu barındırsın)IGenericRepositoryden TEntity için miras al.
//Generic bir yapı generic bir yapıdan miras alıyor; bir boşluk bırakıp şu kıstı kullanmamızı bekler;TEntity nin br class olma zorunluluğunu belirtmiş oluruz.Mutlaka bir class olsun;Interface olmasın bir tip olsun

//EntityFrameWorkCore yapısını kurduğumuzda projemize veri tabanıyla ilgili tüm işlerimizin kalbi larak =Contexti söylemiştik (AppDbContext)ten br nesne oluşturup ve o nesnede context olsun mesela context.Categoris diyecem ki buna ulaşabileyim.Herşeyi oaradan yükleycek çünkü.Burdan oluşmuş i nesne sayesinden.Böyle bir nesneye new deyip oluşturarak mı erişmeliyim? Bu uygulamada program ayağa kalktığında bir tane oluşsa bu bize yeter;classı da static olmayack.Başka bir teknik=)Süreci düşün bu uygulama ayağa kalkerken (çalışırken)bir defa bunu üretsin ve bunu benim için bir yerde tutsun bekletsin ben ne zaman lazım olursa onu alıp kullanayım;Bunun olması için Program cs dosyamıza gideriz(Bizim uygulumamızı ayağa kaldıran program cs)
//Program cs te oluştu bunu buraya nasıl alıcam?=Uygulama çalıştığı anda IOS de konteyner da duruyor bizim onu istediğimiz bir classın içine enjekte etmemiz gerekiyor(dependecy enjection)bağımlılık.ürettiğim dbContext imi buraya almak istiyorum istediğim classın içine;alınca içinde tutmak için bir değişen uyguluyruz dışarıdan erişilmeyeceği için Private,herhangi bir şekilde üzerinde benim gidip onu değiştirmem söz konusu olmamalı korumak için;readonly yazarım.(o değişkenin değerini değiştirmeyeyim)tipi DbContext olacak,EntityFramevorkdeki DbContext(kapsayıcı olduğu için) readonly olarak hazırladığımız değişkenlerin ismi genellikle C# ta _ ile başlatırız.(kullanmadığımız değişkenler açık gri)almak için ctor ile alırım(cobstructer espirisi dışarıdan birşey gelir ve ben bunu kullanabilirm)içerdeki olan değişkeni içerdei olan değişenle dolduruyoruz yani.(OOP)
//nasıl kullanıcam ?Önce GetAll la başladık;Liste tutacacak bir değişken lazım ,TEntity tipinde bir değişken adıda geri döndüreceğimiz birden fazla entityi barındıracağı için entities oldu.=deyip _dbContext i elime aldımhangi entityden bahsettiğimi bilmiyorum ama dışardan gelmiş TEntity işte onu Set(methodnu)ediyoruz.Sonra bir Linq sordusu var ToList.=)GnericRepository de<TEntity> içine mesela Category tipini gönderdim,List<TEntity> Category tipinde birşey döndürecek demektir.Bütün Cateroyleri Listelemiş olacak,en son da geri döndürürüz(entitiesi).