using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }

        public int OgrenciId { get; set; }

        public Ogrenci Ogrenci { get; set; } = null!; // Bu satır ile navigation property yapılır. ÖğrenciId ile Ogrenci tablosuna otomatik join işlemi yapılmış olur.
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!; // Kurs ile KursKayit tablosu arasında ilişki olduğunu belirtir.

        public DateTime KayitTarihi { get; set; }
        
    }
}