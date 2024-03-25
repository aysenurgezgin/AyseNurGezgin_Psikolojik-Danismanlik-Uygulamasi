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