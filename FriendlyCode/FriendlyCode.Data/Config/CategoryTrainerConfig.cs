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
    public class CategoryTrainerConfig : IEntityTypeConfiguration<CategoryTrainer>
    {
        public void Configure(EntityTypeBuilder<CategoryTrainer> builder)
        {
           builder.HasKey(x => new { x.CategoryId, x.TrainerId });
            //PrimaryKey olması için
            builder.ToTable("CategoryTrainers");
        }
    }
}
