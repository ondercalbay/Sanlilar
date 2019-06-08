using Sanlilar.BL;
using Sanlilar.CommonLibrary.Helpers;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using Sanlilar.WebUITermalOtel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Sanlilar.WebUITermalOtel.Controllers
{
    public class HomeController : Controller
    {
        ISayfaManager sayfaManager = new SayfaManager(null, new EfSayfaDal());
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
            //Directory.EnumerateFiles(Server.MapPath("~/images/Site/galeri"))
            return View(Directory.GetFiles(Server.MapPath("~/images/Site/galeri")));
        }

        [Route("/Eynal")]
        public ActionResult Eynal()
        {
            return View(sayfaManager.Get(EnuSayfaTipleri.Termal_Eynal));
        }

        [Route("/Rezervasyon")]
        public ActionResult Rezervasyon()
        {
            return View(new RezervasyonDto());
        }

        [HttpPost]
        public ActionResult Rezervasyon(RezervasyonDto rezervasyonBilgileri)
        {          
            try
            {
                if (ModelState.IsValid)
                {
                    List<Mail> mailler = new List<Mail>();
                    string konu = "Şifa Termal Rezervasyon İstek";
                    Mail mail = new Mail(MailGonderen.sistem, ConfigHelper.Read("RezervasyonMailleri"), "", konu, GetMailStr(rezervasyonBilgileri));
                    mailler.Add(mail);
                    MailHelper.SentMail(mail);
                    rezervasyonBilgileri.bildirim = Helper.GetMesaj(Helper.EnuMesajTuru.success, "Rezervason bilgisi", "Rezervasyon bilginiz alınmışmıştır. </br> En yakın sürede sizinle iletişime geçeceğiz.");
                }
                else
                {
                    rezervasyonBilgileri.bildirim = Helper.GetMesaj(Helper.EnuMesajTuru.warning, "Eksik", "Eksik bilgileri doldurunuz.");
                }   
            }
            catch (Exception ex)
            {
                rezervasyonBilgileri.bildirim = Helper.GetMesaj(Helper.EnuMesajTuru.warning, "Eksik", ex.Message);                
            }

            return View(rezervasyonBilgileri);
        }

        private string GetMailStr(RezervasyonDto rb)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FileHelper.ReadFile("/Content/MailTemplate/RezervasyonMailTemplate.html"));
            sb.Replace("{ADSOYAD}", rb.adSoyad);
            sb.Replace("{EPOSTA}", rb.eposta);
            sb.Replace("{TELEFON}", rb.telefon);
            sb.Replace("{GIRISTARIHI}", rb.girisTarihi.ToDateStr());
            sb.Replace("{CIKISTARIHI}", rb.cikisTarihi.ToDateStr());
            sb.Replace("{MESAJ}", rb.mesaj);


            return sb.ToString();
        }

        [Route("/RezervasyonOnay")]
        public ActionResult RezervasyonOnay()
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