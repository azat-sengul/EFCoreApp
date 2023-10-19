using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{

    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; } 
        public string? OgretmenAdi { get; set; }
        public string? OgretmenSoyadi { get; set; }

        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)] //sadece tarih bilgisini alır
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)] // bilgi görüntüleme şekli
        public DateTime BaslamaTarihi { get; set; }

        //Bir öğretmen birden fazla kursta da ders verebilir. Bunun için;

        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();

    }
}

