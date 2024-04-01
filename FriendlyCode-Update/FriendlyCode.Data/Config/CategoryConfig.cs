using FriendlyCode.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Category ile ilgili özellikler vermek istediğim için;döngü(lamda expression) değişkenimin ismi de c olsun dedim,döngü her döndüğünde sırada ki categoriye c adını vericek(foreach de ki in den önce yazdığımız değişken adı gibi)

           builder.HasKey(c => c.Id);//her kategorinin id si c olsun dedik.Primary key yapmak için
           builder.Property(c => c.Id).ValueGeneratedOnAdd();//ekleme yapıldığında değer üret.IdentitySpeficitation
           builder    
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
           builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

           builder
               .Property(c => c.Url)
               .IsRequired()
               .HasMaxLength(500);
            builder
               .ToTable("Categories");

            //Veri tabanına aktarma işini yaparken aynı zamanda örnek verilerin de girilimesini istiyorum category tabl içine;
             builder
                .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Birebir",
                    Description = "Birebir kategori",
                    Url = "birebir"
                },
                new Category
                {
                    Id = 2,
                    Name = "Grup",
                    Description = "Grup kategorisi",
                    Url = "grup"
                }

                );
        }
    }
}
//IEntityTypeConfiguration içinde method imzası (publiv void diye başlayan kısım)varmış,bu methodun yazılması gerektiği için .=miras alma ve implemente etme sebebimiz;dışarıdan tipi EntityTypeBuilder ama o da generic category olan(cayegory diye birşeyi bilemez EntityFramework)imza olarak vermiş ve senin ihtiyacın neyse onu ver diyor.builder 'da=her bir category'den bahsetmeye çalıştığımız da modelBuilder aldık elimize işte o hatta daha fazlası Category Entitysinden bahsettiktiğimizi belirtiyorduk appDbContext'te ama burada implemente ettiğimizde bunu burada söylemiş oluyoruz;Category'e göre özelleştirilmiş bir alan artık burası.Bu şekilde CleanCode yapmış olduk.