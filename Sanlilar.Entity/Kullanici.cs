using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Entity
{
    [Table("Kullanicilar", Schema = "Sistem")]
    public class Kullanici
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }
        [Required]
        [MaxLength(50)]
        public string KullaniciAdi { get; set; }
        [Required]
        [MaxLength(20)]
        public string Sifre { get; set; }
        [Required]
        [MaxLength(100)]
        public string EPosta { get; set; }
        public int EkleyenId { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int GuncelleyenId { get; set; }
        public DateTime GuncellemeZamani { get; set; }
        public bool Aktif { get; set; }
    }
}
