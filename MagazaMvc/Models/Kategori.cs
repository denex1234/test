using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazaMvc.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        public string KategoriAdi { get; set; }
        public int KategoriSira { get; set; }
    }
}