using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanlilar.Entity
{
    [Table("Urunler", Schema = "Eticaret")]
    public class Urun : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        public decimal Fiyat { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "AnaResim")]
        public int AnaResimId { get; set; }
    }
}
