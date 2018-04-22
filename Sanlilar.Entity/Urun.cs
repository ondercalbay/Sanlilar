using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Entity
{
    [Table("Urunler", Schema = "Mobilya")]
    public class Urun : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

        [Required]
        public int KategoriId { get; set; }

        public decimal Fiyat { get; set; }

        public string Aciklama { get; set; }
    }
}
