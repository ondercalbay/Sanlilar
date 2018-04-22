using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Entity
{
    [Table("AnaKategoriler", Schema = "Sanlilar")]
    public class AltKategori : BaseEntity
    {

        public int UstKategoriId { get; set; }
    }
}
