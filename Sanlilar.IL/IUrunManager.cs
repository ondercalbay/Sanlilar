using Sanlilar.Dto;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.IL
{
    public interface IUrunManager : IGenericManager<Urun, UrunListDto, UrunEditDto>
    {
    }
}
