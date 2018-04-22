using System.ComponentModel.DataAnnotations;

namespace Sanlilar.Dto
{
    public class KullaniciEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string Adi { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Soyad")]
        public string Soyadi { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }


        [Required]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string SifreTekrar { get; set; }

        [Required]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        public string EPosta { get; set; }

        public int EkleyenId { get; set; }
        public int GuncelleyenId { get; set; }

    }
}
