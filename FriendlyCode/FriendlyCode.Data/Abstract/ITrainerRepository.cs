using FriendlyCode.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyCode.Data.Abstract
{
    public interface ITrainerRepository:IGenericRepository<Trainer>
    {
        //Trainer'a özgü methot imzalarımızı buraya yazacağız.
        List<Trainer>GetTrainersByCategoryId(int categoryId);
    }
}
//Bu içinde ıGenericRepository içinde ki methotları barındırmalı ama Trainerlarla ilgili işler yapıcam fakat IGnericRepository Gneric yazılmış yani genel olarak yazılmış bişey ama IGenericRepository sen bana TEntiy verirsen ben ona göre yapılandırıcam deme imkanı veriyordu o zamn bnde<>içine Triner için hazırla derim.(Bir inreface e başka bir interfcace den miras aldırırsak implemente edecek birşey olmaz çünkü burda da kod yok)classtan class a  miraz almış gibiyim.(Orda ne varsa buaraya da o özellikleri eklemiş oluruz)IGenericRepository içinde ne varsa bunun içinde de o var.Fakat Trainer için olnaları var artık.