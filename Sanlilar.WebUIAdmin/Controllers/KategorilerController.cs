using Sanlilar.BL;
using Sanlilar.DL.EntityFramework;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using Sanlilar.WebUIAdmin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sanlilar.WebUIAdmin.Controllers
{
    public class KategorilerController : Controller
    {
        IKategoriManager _manager = new KategoriManager(UserHelper.Id, new EfKategoriDal());
        // GET: Kategoriler
        public ActionResult Index()
        {
            return View(_manager.Get(new Kategori()));
        }

        // GET: Kategoriler/Edit/5
        public ActionResult Edit(int? id, int? ustKategoriId)
        {
            KategoriEditDto editDto;
            if (id == null)
            {
                editDto = new KategoriEditDto();
                if (ustKategoriId != null)
                {
                    editDto.UstKategoriId = ustKategoriId;
                }
            }
            else
            {
                editDto = _manager.Get(Convert.ToInt32(id));
            }

            IEnumerable<KategoriListDto> kategoriler = _manager.Get(new Kategori());
            List<SelectListItem> selectkategoriler = new SelectList(kategoriler, "Id", "Adi", editDto.UstKategoriId).ToList();

            selectkategoriler.Insert(0, new SelectListItem() { Value = "", Text = "Seçiniz" });
            ViewBag.UstKategoriId = selectkategoriler;
            return View(editDto);
        }

        // POST: Kategoriler/Edit/5
        [HttpPost]
        public ActionResult Edit(KategoriEditDto editDto)
        {
            ViewBag.Message = "Sayfalar";
            ViewBag.UstKategoriler = _manager.Get(new Kategori());
            if (editDto.Id == 0)
            {
                _manager.Add(editDto);
            }
            else
            {
                _manager.Update(editDto);
            }
            return RedirectToAction("");

        }

        // GET: Kategoriler/Delete/5
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("");
        }

        // POST: Kategoriler/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _manager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
