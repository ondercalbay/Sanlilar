using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sanlilar.WebUITermalOtel.Models
{
    public class RezervasyonDto
    {
        public string adSoyad { get; set; }
        public string eposta { get; set; }
        public string telefon { get; set; }
        public DateTime girisTarihi { get; set; }
        public DateTime cikisTarihi { get; set; }
        public string mesaj { get; set; }
    }
}