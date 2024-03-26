using FriendlyCode.Data.Config;
using FriendlyCode.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<CategoryTrainer> CategoryTrainers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=FriendlyCode.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new TrainerConfig());
            modelBuilder.ApplyConfiguration(new CategoryTrainerConfig());



            base.OnModelCreating(modelBuilder);
        }
    }
}
//Tablo oluştumak için tip;DbSet veri tabanında tablo yapmam gereken şeyin ne olduğunu ifade eder.List yapısı gibi Generic(<> işaretinden)içinde şunları tutan diye belirtmelisin anlamında 
//ve DbContext 'i override ediyoruz(conection string)bağlantı kuracagımız bilgiyi koymuş oluyoruz.
//*base =miras aldığımız class,onConfiguring=methotdumuzun ismi;
//base.onconfiguring içine optionsBuilder gönder demiş olduk.
//(.net'e biz demeliyiz)C#tan Sqlite a göç=migrations 'larla göç dosyası hazırlamalıyız (Entity FrameworkCore demiş)1)göç dosyası=migrations aşaması,2)o dosyayı çalıştırma =update açaması=) entity Framework Coru'u Data ya kurduğumuz için orada bir terminal açarız(oraya yükledik)
//veri tabanın da yapılan değişikler için de her sefernde add diyerek migration eklemeliyiz.
//2.onmeodel Crating=model oluşturulurken bu tablo olsun vs.olmadan önce belirtmen gerkenler varsa kısmı.

//Config oluşturduktan sonra belirtmemiz gerek şurayı da çalıştır diye.Ya da tüm Cofig dosyalarını çalıştır diye.
//OnModelCreatin ne zaman çalışıyor?=migration model in oluşmasını sağlıyor,o esnada çalışıyor modelBuilder'lar(ve sırası önemli önce yeni bir CategoryConfig nesnesi oluşturacağı için CategoryConfig in Configure methodu çalışacak.(constractur'ında oluşum anında))
//*Data katmanın da migration hatası aldığın zaman başlangıç projesinde (Mvc de)bir terminal açarak dotnet build komutunu ver,hatan(kopyalayamıyorum gibi) migration oluşturmadan önce projeyi daha öncesinde ayağa kaldırmış ve migrtion oluştururken onu durdurmaman da olabilir.Ya da bin ve obj dosyalarını silip tekrar deneyebilirsin.