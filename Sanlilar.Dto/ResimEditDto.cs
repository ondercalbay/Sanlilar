using System.ComponentModel.DataAnnotations;

namespace Sanlilar.Dto
{
    public class ResimEditDto
    {
        [Required]
        [MaxLength(50)]
        public string ElementTipi { get; set; }

        [Required]
        public string ResimYolu { get; set; }

        [Required]
        public bool AnaResim { get; set; }
    }
}
