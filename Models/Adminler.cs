using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    [Table("Adminler")]
    public class Adminler
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20),Required]
        public string AdminAdi { get; set; }
        [StringLength(20), Required]
        public string Sifre { get; set; }
        public bool? Aktifmi { get; set; }
    }
}