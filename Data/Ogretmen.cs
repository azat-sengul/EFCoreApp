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

        public DateTime BaslamaTarihi { get; set; }

        //Bir öğretmen birden fazla kursta da ders verebilir. Bunun için;

        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();

    }
}

