using Sanlilar.DL.Abstract;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sanlilar.DL.EntityFramework
{
    public class EfResimDal : IResimDal
    {
        private SanlilarContext _context = new SanlilarContext();

        public Resim Add(Resim ent)
        {
            _context.Resimler.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        public void Delete(int id, int userId)
        {
            var ent = Get(id);
            ent.GuncelleyenId = userId;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<Resim> Get(Resim filter)
        {
            return _context.Resimler.Where(t =>
             (filter.Id == 0 || t.Id == filter.Id) &&
             (filter.ElementTipi == 0 || t.ElementTipi == filter.ElementTipi) &&
             (filter.ElementId == 0 || t.ElementId == filter.ElementId) &&
             t.Aktif == true).ToList();
        }

        public Resim Get(int id)
        {
            return Get(new Resim { Id = id }).FirstOrDefault();
        }

        public Resim Update(Resim ent)
        {
            Resim newEnt = Get(ent.Id);
            newEnt.ElementTipi = ent.ElementTipi;
            newEnt.ElementId = ent.ElementId;
            newEnt.ResimYolu = ent.ResimYolu;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}