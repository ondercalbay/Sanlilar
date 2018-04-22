using System.ComponentModel.DataAnnotations;

namespace Sanlilar.Dto
{
    public class UrunEditDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

        [Required]
        public int KategoriId { get; set; }

        public decimal Fiyat { get; set; }

        public string Aciklama { get; set; }
    }
}
