using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.Dto
{
    public class ResimListDto
    {
        [Required]
        public string ResimYolu { get; set; }

        [Required]
        public bool AnaResim { get; set; }
    }
}
