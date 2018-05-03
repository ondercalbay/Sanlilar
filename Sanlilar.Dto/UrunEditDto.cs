using System.ComponentModel.DataAnnotations;

namespace Sanlilar.Dto
{
    public class UrunEditDto
    {
        public int Id { get; set; }

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

        public ResimEditDto Resim { get; set; }
    }
}
