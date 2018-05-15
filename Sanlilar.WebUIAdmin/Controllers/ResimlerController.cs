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
    public class ResimlerController : Controller
    {
        IResimManager _ResimManager = new ResimManager(UserHelper.Id, new EfResimDal());
        IKategoriManager _KategoriManager = new KategoriManager(UserHelper.Id, new EfKategoriDal());

        // GET: Resimlar
        public ActionResult Index(int? ElementTipiId, int? ElementId)
        {
            Resim filter = new Resim();
            if (ElementTipiId != null)
            {
                filter.ElementTipi = (EnuElementler)ElementTipiId;
            }
            if (ElementId != null)
            {
                filter.ElementId = Convert.ToInt32(ElementId);
            }
            return View(_ResimManager.Get(filter));
        }


        public ActionResult Edit(int? id, int? ElementTipiId, int? ElementId)
        {
            ResimEditDto editDto;
            if (id == null)
            {
                editDto = new ResimEditDto();
            }
            else
            {
                editDto = _ResimManager.Get(Convert.ToInt32(id));
            }

            if (ElementTipiId != null)
            {
                editDto.ElementTipi = (EnuElementler)ElementTipiId;
            }

            if (ElementId != null)
            {
                editDto.ElementId = (int)ElementId;
            }

            var elementler = Enum.GetValues(typeof(EnuElementler)).Cast<EnuElementler>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();


            List<SelectListItem> selectElementler = new SelectList(elementler, "Value", "Text", editDto.ElementTipi).ToList();

            selectElementler.Insert(0, new SelectListItem() { Value = "", Text = "Seçiniz" });
            ViewBag.ElementTipi = selectElementler;

            return View(editDto);
        }

        // POST: Resimlar/Edit/5
        [HttpPost]
        public ActionResult Edit(ResimEditDto editDto)
        {
            ViewBag.Message = "Resimlar";
            if (editDto.Id == 0)
            {
                _ResimManager.Add(editDto);
            }
            else
            {
                _ResimManager.Update(editDto);
            }
            return RedirectToAction("");

        }



        // GET: Resimlar/Delete/5
        public ActionResult Delete(int id)
        {
            _ResimManager.Delete(id);
            return RedirectToAction("");
        }
    }
}
