using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanlilar.Entity
{
    [Table("Resimler", Schema = "Mobilya")]
    public class Resim : BaseEntity
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
