using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazaMvc.Models
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string UrunKategori { get; set; }

        public string UrunResmi { get; set; }

        public string UrunAciklama { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public double UrunFiyat { get; set; }

        public DateTime UrunTarih { get; set; }
    }
}