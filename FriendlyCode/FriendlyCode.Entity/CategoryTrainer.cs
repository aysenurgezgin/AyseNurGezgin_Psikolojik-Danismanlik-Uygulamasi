using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Entity
{
    public class CategoryTrainer
    {
        public int CategoryId { get; set; }
        //public int TrainerId { get; set; }
        //Config
    }
}
//Forein Key'ler 
//Category ve Trainer'ları eşleştirmek için kullanacağımız (junction table)çoka çok ilişki olduğu için.