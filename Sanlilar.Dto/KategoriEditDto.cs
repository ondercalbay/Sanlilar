using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Dto
{
    public class KategoriEditDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int? UstKategoriId { get; set; }
    }
}
