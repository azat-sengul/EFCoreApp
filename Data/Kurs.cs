using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>(); // Bu satırı her bir kursa  kayıtlı öğrencilerin bilgilerine de getirecek
        
    }
}