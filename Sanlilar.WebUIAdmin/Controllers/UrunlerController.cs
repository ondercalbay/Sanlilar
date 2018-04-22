using Sanlilar.BL;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using Sanlilar.WebUIAdmin.Helpers;
using System;
using System.Web.Mvc;

namespace Sanlilar.WebUIAdmin.Controllers
{
    public class UrunlerController : Controller
    {
        IUrunManager _UrunManager = new UrunManager(UserHelper.Id, new EfUrunDal());

        // GET: Urunlar
        public ActionResult Index()
        {
            return View(_UrunManager.Get(new Urun()));
        }

        public ActionResult Edit(int? id)
        {
            UrunEditDto editDto;
            if (id == null)
            {
                editDto = new UrunEditDto();
            }
            else
            {
                editDto = _UrunManager.Get(Convert.ToInt32(id));
            }
            return View(editDto);
        }

        // POST: Urunlar/Edit/5
        [HttpPost]
        public ActionResult Edit(UrunEditDto editDto)
        {
            ViewBag.Message = "Urunlar";
            if (editDto.Id == 0)
            {
                _UrunManager.Add(editDto);
            }
            else
            {
                _UrunManager.Update(editDto);
            }
            return RedirectToAction("");

        }



        // GET: Urunlar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
