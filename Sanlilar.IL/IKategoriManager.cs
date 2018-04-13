using Sanlilar.Dto;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.IL
{
    public interface IKategoriManager : IGenericManager<Kategori, KategoriListDto, KategoriEditDto>
    {
        KategoriEditDto Get(int? id);
    }
}
