using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("No")]
        public int OgrenciId { get; set; }

        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }

        // Öğrenci ad soyad veri tabanından gelen bilgilerle birleştirilmek istenirse

        public string AdSoyad 
        { get
            {
                return this.OgrenciAdi + " " + this.OgrenciSoyadi;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>(); // Bu satırı her bir öğrencinin kurs kayıt bilgilerine de getirecek


    }
}