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
        public Category Category { get; set; }//Nav.Prop olucak
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
//Forein Key'ler 
//Category ve Trainer'ları eşleştirmek için kullanacağımız (junction table)çoka çok ilişki olduğu için.