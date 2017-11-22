using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.DL.Abstract
{
    public interface ISayfaDal : IGenericDal<Sayfa>
    {
        Sayfa Get(EnuSayfaTipleri sayfaTipi);
    }
}
