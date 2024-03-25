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

        }
    }
}
//builder deyince ne anlıycam?=modelBuilder.EntityTrainer diyince anladığım şeyi anlamam gerekiyor dolayısıyla;Trainerla ilgili ayarlarımı yapabilecek durumdayım.