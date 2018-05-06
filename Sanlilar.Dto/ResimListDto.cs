using Sanlilar.Entity;
using System.ComponentModel.DataAnnotations;

namespace Sanlilar.Dto
{
    public class ResimListDto
    {
        public int Id { get; set; }
        
        public EnuElementler ElementTipi { get; set; }

        public string ResimYolu { get; set; }
    }
}
