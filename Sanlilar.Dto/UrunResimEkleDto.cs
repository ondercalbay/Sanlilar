using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Dto
{

    public class UrunResimEkleDto
    {
        public int Id { get; set; }

        public List<ResimListDto> Resimler { get; set; }
    }
}
