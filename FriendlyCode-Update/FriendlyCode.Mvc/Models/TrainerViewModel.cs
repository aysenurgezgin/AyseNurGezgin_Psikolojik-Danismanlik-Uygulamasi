namespace FriendlyCode.Mvc.Models
{
    public class TrainerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public string Url { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
//Bir Trainer'ın hangi özelliklerini kullanıcıyla paylaşmak istiyorsak buraya o bilgileri yazıcaz.(bizimde işimize yarayanları yazıcaz mesela:id=detay bilglierini çekicem veri tabanından)
//Bunu oluşturma sebebim=Service katmanımda Trainer olarak değil TrainerViewModel olarak tanımlmaktı ama sıkıntı var referans mantığı(bussines Mvcye erişimi gerekiyor) ;burada Core katmanı işimize yarıyor