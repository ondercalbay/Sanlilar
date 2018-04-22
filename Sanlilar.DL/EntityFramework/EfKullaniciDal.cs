using Sanlilar.DL.Abstract;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.DL.EntityFramework
{
    public class EfKullaniciDal : IKullaniciDal
    {
        private SanlilarContext _context = new SanlilarContext();

        public Kullanici Add(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return kullanici;
        }

        public void Delete(int id, int userId)
        {
            Kullanici kullaniciUpdate = Get(id);
            if (kullaniciUpdate == null)
            {
                throw new Exception("Kullanici bulunamadığı için silme işlemi yapılamadı.");
            }
            kullaniciUpdate.GuncelleyenId = userId;
            kullaniciUpdate.GuncellemeZamani = DateTime.Now;
            kullaniciUpdate.Aktif = false;
            _context.SaveChanges();
        }

        public List<Kullanici> Get(Kullanici search)
        {
            var kullanicilarDto = _context.Kullanicilar
                .Where(k =>
                        (search.Id == 0 || k.Id == search.Id) &&
                        (search.Adi == null || k.Adi == search.Adi) &&
                        (search.Soyadi == null || k.Soyadi == search.Soyadi) &&
                        (search.KullaniciAdi == null || k.KullaniciAdi == search.KullaniciAdi) &&
                        (search.EPosta == null || k.EPosta == search.EPosta) &&
                        (search.Sifre == null || k.Sifre == search.Sifre) &&
                        k.Aktif == true
                )
                .OrderByDescending(k => k.EklemeZamani).ToList();

            return kullanicilarDto;
        }

        public Kullanici Get(int id)
        {
            return _context.Kullanicilar.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
        }

        public Kullanici Update(Kullanici ent)
        {
            Kullanici newEnt = Get(ent.Id);
            newEnt.Adi = ent.Adi;
            newEnt.Soyadi = ent.Soyadi;
            newEnt.KullaniciAdi = ent.KullaniciAdi;
            newEnt.Sifre = ent.Sifre;
            newEnt.EPosta = ent.EPosta;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
