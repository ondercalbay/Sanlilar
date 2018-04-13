using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanlilar.Entity
{

    [Table("Kategori", Schema = "Mobilya")]
    public class Kategori : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

        public int? UstKategoriId { get; set; }
    }

}
