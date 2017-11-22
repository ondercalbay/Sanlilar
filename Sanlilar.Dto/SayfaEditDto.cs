using Sanlilar.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sanlilar.Dto
{
    public class SayfaEditDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowHtml]
        public string Html { get; set; }
        [Required]
        public EnuSayfaTipleri SayfaTipi { get; set; }
    }
}
