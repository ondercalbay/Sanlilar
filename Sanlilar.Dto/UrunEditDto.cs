using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Fiyat { get; set; }

        [Display(Name = "Açıklama")]
        [AllowHtml]
        public string Aciklama { get; set; }

        public ResimEditDto Resim { get; set; }
    }
}
