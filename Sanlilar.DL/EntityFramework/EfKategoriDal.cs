using Sanlilar.DL.Abstract;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sanlilar.DL.EntityFramework
{
    public class EfKategoriDal : IKategoriDal
    {
        private SanlilarContext _context = new SanlilarContext();

        public Kategori Add(Kategori ent)
        {
            _context.Kategoriler.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        public void Delete(int id)
        {
            var ent = Get(id);
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<Kategori> Get(Kategori filter)
        {
            var query = _context.Kategoriler.Where(t =>
           (filter.Id == 0 || t.Id == filter.Id) &&
           (filter.UstKategoriId == null || t.UstKategoriId == filter.UstKategoriId) &&
           (filter.Adi == null || t.Adi == filter.Adi) &&
           t.Aktif == true);
            return query.ToList();
        }

        public Kategori Get(int id)
        {
            return Get(new Kategori { Id = id }).FirstOrDefault();
        }

        public Kategori Update(Kategori ent)
        {
            Kategori newEnt = Get(ent.Id);
            newEnt.Adi = ent.Adi;
            newEnt.UstKategoriId = ent.UstKategoriId;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
