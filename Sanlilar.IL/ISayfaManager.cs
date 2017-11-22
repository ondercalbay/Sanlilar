using Sanlilar.Dto;
using Sanlilar.Entity;

namespace Sanlilar.IL
{
    public interface ISayfaManager : IGenericManager<Sayfa, SayfaListDto, SayfaEditDto>
    {
        SayfaDetailDto Get(EnuSayfaTipleri termal_Hakkimizda);
    }
}
