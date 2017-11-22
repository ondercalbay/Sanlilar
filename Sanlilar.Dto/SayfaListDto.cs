using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sanlilar.Dto
{
    public class SayfaListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EnuSayfaTipleri SayfaTipi { get; set; }
    }
}
