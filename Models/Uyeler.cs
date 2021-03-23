using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    [Table("Uyeler")]
    public class Uyeler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20), Required]
        public string KullaniciAdi { get; set; }
        [StringLength(20), Required]
        public string Parola { get; set; }
        public bool? Aktifmi { get; set; }
        public bool Adminmi { get; set; }
    }
}