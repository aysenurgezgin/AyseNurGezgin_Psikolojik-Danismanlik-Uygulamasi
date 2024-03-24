using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Entity
{
    public class Trainer
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }//özellik
        public decimal Price { get; set; }//seans ücret
        public bool IsHome { get; set; }//anasayfada göst
        public string ImageUrl { get; set; }//resim
        //Navigation Property;
        public List<CategoryTrainer> CategoryTrainers { get; set; }

    }
}

//Classlar arası ilişki kurmuş olduk ,bizim işimiz;tablolarımız arasında ilişki kurmak(ayrıca aramak gibi bir işten de kurtarmış oldu CategoryTrainer)=Navigation Property