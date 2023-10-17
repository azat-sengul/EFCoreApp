using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }

        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyadi { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
    }
}