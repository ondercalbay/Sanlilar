using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanlilar.Entity
{
    [Table("Resimler", Schema = "Sistem")]
    public class Resim : BaseEntity
    {
        [Required]
        public EnuElementler ElementTipi { get; set; }

        [Required]
        public int ElementId { get; set; }

        [Required]
        public string ResimYolu { get; set; }
        
    }
}
