using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    [Table("Urunler")]
    public class Urunler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20), Required]
        public string Ad { get; set; }
        public bool Indirim { get; set; }
        public bool Erkekmi { get; set; }
        public string Resim { get; set; }         
        [Required]
        public int Fiyat { get; set; }
    }
}