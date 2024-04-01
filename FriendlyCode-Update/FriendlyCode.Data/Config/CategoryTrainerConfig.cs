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
            //Örnekdata işlemi;
            builder.HasData(
              new CategoryTrainer { TrainerId = 1, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 1, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 2, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 2, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 3, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 3, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 4, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 4, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 5, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 5, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 6, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 6, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 7, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 7, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 8, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 8, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 9, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 9, CategoryId = 2 },

              new CategoryTrainer { TrainerId = 10, CategoryId = 1 },
              new CategoryTrainer { TrainerId = 10, CategoryId = 2 }
         




                );
        }
    }
}
