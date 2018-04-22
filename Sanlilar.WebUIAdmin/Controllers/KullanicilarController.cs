using Sanlilar.BL;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using Sanlilar.WebUIAdmin.Helpers;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Sanlilar.WebUIAdmin.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciManager _servis = new KullaniciManager(UserHelper.Id, new EfKullaniciDal());

        public KullanicilarController(IKullaniciManager kullaniciServis)
        {
            _servis = kullaniciServis;

        }

        public ActionResult Login()
        {
            return View(new KullaniciLoginDto());
        }

        [HttpPost]
        public ActionResult Login(KullaniciLoginDto kullanici, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                KullaniciEditDto kullaniciAuth = _servis.Authenticate(kullanici);
                if (kullaniciAuth == null)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı.");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(kullaniciAuth.KullaniciAdi, false);
                    return Redirect(returnUrl ?? "/");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        // GET: Kullanici
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Kullanicilar";

            return View(_servis.Get(new Kullanici { Aktif = true }));
        }

        //public ActionResult Edit()
        //{
        //    KullaniciEditDto kullaniciDto = new KullaniciEditDto();
        //    if (Request["id"] != "")
        //    {
        //        ViewBag.Message = "Kullanicilar Düzenle";
        //        kullaniciDto = _servis.Get(Convert.ToInt32(Request["id"]));
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Kullanicilar Yeni";
        //    }

        //    return View(kullaniciDto);
        //}
        [Authorize]
        public ActionResult Edit(int? id)
        {
            KullaniciEditDto kullaniciDto = new KullaniciEditDto();
            if (id != null)
            {
                ViewBag.Message = "Kullanicilar Düzenle";
                kullaniciDto = _servis.Get(Convert.ToInt32(id));
                kullaniciDto.SifreTekrar = kullaniciDto.Sifre;
            }
            else
            {
                ViewBag.Message = "Kullanicilar Yeni";
            }

            return View(kullaniciDto);
        }

        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Message = "Kullanicilar";
        //    return View(manager.Get(id));
        //}

        [Authorize]
        [HttpPost]
        public ActionResult Edit(KullaniciEditDto kullanici)
        {
            ViewBag.Message = "Kullanicilar";
            if (kullanici.Id == 0)
            {
                _servis.Add(kullanici);
            }
            else
            {
                _servis.Update(kullanici);
            }
            return RedirectToAction("");

        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _servis.Delete(id);
            return RedirectToAction("");

        }
    }
}