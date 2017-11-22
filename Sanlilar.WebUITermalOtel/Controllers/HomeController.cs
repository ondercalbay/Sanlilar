using Sanlilar.BL;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System.Web.Mvc;

namespace Sanlilar.WebUITermalOtel.Controllers
{
    public class HomeController : Controller
    {
        ISayfaManager sayfaManager = new SayfaManager(new EfSayfaDal());
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("/Hakkimizda")]
        public ActionResult Hakkimizda()
        {            
            return View(sayfaManager.Get(EnuSayfaTipleri.Termal_Hakkimizda));
        }

        [Route("/Odalarimiz")]
        public ActionResult Odalarimiz()
        {
            return View();
        }

        [Route("/Galeri")]
        public ActionResult Galeri()
        {
            return View();
        }

        [Route("/Eynal")]
        public ActionResult Eynal()
        {
            return View(sayfaManager.Get(EnuSayfaTipleri.Termal_Eynal));
        }

        [Route("/Rezervasyon")]
        public ActionResult Rezervasyon()
        {
            return View();
        }

        [Route("/Iletisim")]
        public ActionResult Iletisim()
        {
            return View(sayfaManager.Get(EnuSayfaTipleri.Termal_Iletisim));
        }
    }
}