using AutoMapper;
using Sanlilar.Dto;
using Sanlilar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.BL
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            //MapperConfiguration config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<List<Kullanici>, List<KullaniciListDto>>();
            //    cfg.CreateMap<List<KullaniciListDto>, List<Kullanici>>();
            //    cfg.CreateMap<Kullanici, KullaniciEditDto>();
            //    cfg.CreateMap<KullaniciEditDto, Kullanici>();
            //});
            //Mapper.Initialize(cfg =>
            //    cfg.AddProfiles(new[]{
            //        typeof(Kullanici) ,
            //        typeof(KullaniciListDto),
            //        typeof(List<Kullanici>),
            //        typeof(List<KullaniciListDto>),
            //        typeof(KullaniciEditDto)
            //    })
            //);

            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<List<Kullanici>, List<KullaniciListDto>>();
                //cfg.CreateMap<List<KullaniciListDto>, List<Kullanici>>();

                cfg.CreateMap<Sayfa, SayfaListDto>();
                cfg.CreateMap<SayfaListDto, Sayfa>();
                cfg.CreateMap<Sayfa, SayfaEditDto>();
                cfg.CreateMap<SayfaEditDto, Sayfa>();
                cfg.CreateMap<Sayfa, SayfaDetailDto>();
                cfg.CreateMap<SayfaDetailDto, Sayfa>();
            }
            );


        }
    }
}
