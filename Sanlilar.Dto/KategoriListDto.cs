using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Dto
{
    public class KategoriListDto
    {
        public int Id { get; set; }         
        public string Adi { get; set; }
        public int? UstKategoriId { get; set; }
        public string UstKategoriAdi { get; set; }
        public int Duzey { get; set; }
    }
}
