using FriendlyCode.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
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

//EntityFrameWorkCore yapısını kurduğumuzda projemize veri tabanıyla ilgili tüm işlerimizin kalbi larak =Contexti söylemiştik (AppDbContext)ten br nesne oluşturup ve o nesnede context olsun mesela context.Categoris diyecem ki buna ulaşabileyim.Herşeyi oaradan yükleycek çünkü.Burdan oluşmuş i nesne sayesinden.Böyle bir nesneye new deyip oluşturarakmı erişmeliyim? Bu uygulamada program ayağa kalktığında bir tane oluşsa bu bize yeter;classı da static olmayack.Başka bir teknik=)Süreci düşün bu uygulama ayağa kalkerken (çalışırken)bir defa bunu üretsin ve bunu benim için bir yerde tutsun bekletsin ben ne zaman lazım olursa onu alıp kullanayım;Bunun olması için Program cs dosyamıza gideriz(Bizim uygulumamızı ayağa kaldıran program cs)