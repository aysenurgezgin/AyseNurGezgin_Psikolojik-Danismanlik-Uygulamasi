using FriendlyCode.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Config
{
    public class TrainerConfig : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(t => t.Id);//trainerların alanı primaryKey olacak demek
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Properties)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(t => t.Price)
                .IsRequired();
            builder.Property(t => t.ImageUrl) 
                .IsRequired();
            builder.ToTable("Trainers");
            //Örnek Data girme işlemleri başlıyor;
            builder.HasData(
                new Trainer
                {
                    Id=1,
                    Name="Engin Niyazi Ergül",
                    Price="Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                    Properties="Çıktığınız bu yolda yanlız olmadığınızı hissetiren bir kişi.",
                    Url="engin-niyazi",
                    ImageUrl="1.png",
                    IsHome=true
                },
                new Trainer
                 {
                     Id = 2,
                     Name = "Aylin Gezer",
                     Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                     Properties = "Mantığınızla duygularınız arasında karar vermenize yardımcı olacak bir kişi.",
                     Url="aylin",
                     ImageUrl = "2.png",
                     IsHome = true
                 },
                new Trainer
                  {
                      Id = 3,
                      Name = "Mert Güneş",
                      Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                      Properties = "İş seçiminde ve iş hayatınızda size yardımcı olacak bir kişi.",
                      Url="mert",
                      ImageUrl = "3.png",
                      IsHome = true
                  },
                new Trainer
                  {
                      Id = 4,
                      Name = "Asya Gümüş",
                      Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                      Properties = "Aile hayatınızda çıkmazlara geldiğinizi hissettiğinizde yardımcı olacak bir kişi.",
                      Url="asya",
                      ImageUrl = "4.png",
                      IsHome = false
                  },
                new Trainer
                   {
                      Id = 5,
                      Name = "Erkan Kocakaya",
                      Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                      Properties = "Sağlıklı şekilde spor ve hayat çizgisinde kalmanızı sağlayacak bir kişi.",
                      Url="erkan",
                      ImageUrl = "5.png",
                      IsHome = true
                   },
                new Trainer
                   {
                      Id = 6,
                      Name = "Merve Karadağlı",
                      Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                      Properties = "Üniversiteye hazırlık döneminde ki gençlerimize sağlıklı yön verecek bir kişi.",
                      Url="merve",
                      ImageUrl = "6.png",
                      IsHome = true
                   },
                new Trainer
                   {
                       Id = 7,
                       Name = "Elif Buse Meriç",
                       Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                       Properties = "Çift terapisti olarak sizi dinleyen ve çözüm bulacak bir kişi.",
                       Url="elif-buse",
                       ImageUrl = "7.png",
                       IsHome = true
                    },
                new Trainer
                    {
                       Id = 8,
                       Name = "Ahmet Toprak",
                       Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                       Properties = "Felsefik ya da farklı açıdan kendi çıkmazlarınız da yanınızda olacak bir kişi.",
                       Url="ahmet",
                       ImageUrl = "8.png",
                       IsHome = true
                     },
                new Trainer
                     {
                       Id = 9,
                       Name = "Kemal Sevim",
                       Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                       Properties = "Aile içe huzursuzluklarda ve anlaşmazlıklarda sizi yanlız bırakmayacak bir kişi.",
                       Url="kemal",
                       ImageUrl = "9.png",
                       IsHome = false
                      },
                new Trainer
                      {
                        Id = 10,
                        Name = "Emine Hakyemez",
                        Price = "Ücreti merkezimize geldiğiniz de konuşmayı çok isteriz",
                        Properties = "Evlatlarınızla daha iyi bir iletişim sağlamada size yardımcı olacak bir kişi.",
                        Url="emine",
                        ImageUrl = "10.png",
                        IsHome = true
                       }

                );
        }
    }
}
//builder deyince ne anlıycam?=modelBuilder.EntityTrainer diyince anladığım şeyi anlamam gerekiyor dolayısıyla;Trainerla ilgili ayarlarımı yapabilecek durumdayım.