using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sanlilar.WebUITermalOtel.Models
{
    public class RezervasyonDto
    {
        [Required]
        public string adSoyad { get; set; }        
        public string eposta { get; set; }
        [Required]
        public string telefon { get; set; }
        [Required]
        public DateTime girisTarihi { get; set; }
        [Required]
        public DateTime cikisTarihi { get; set; }
        public string mesaj { get; set; }

        public string bildirim { get; set; }
    }
}