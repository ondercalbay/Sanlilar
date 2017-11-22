using Sanlilar.Entity;
using System.Data.Entity;

namespace Sanlilar.DL.EntityFramework
{
    public class SanlilarContext : DbContext
    {
        public DbSet<Sayfa> Sayfalar { get; set; }
    }
}
