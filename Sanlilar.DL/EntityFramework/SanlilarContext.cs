using Sanlilar.Entity;
using System.Data.Entity;

namespace Sanlilar.DL.EntityFramework
{
    public class SanlilarContext : DbContext
    {
        public DbSet<Sayfa> Sayfalar { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Resim> Resimler { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
