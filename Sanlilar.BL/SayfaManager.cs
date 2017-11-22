using AutoMapper;
using Sanlilar.DL.Abstract;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System;
using System.Collections.Generic;

namespace Sanlilar.BL
{
    public class SayfaManager : ISayfaManager
    {
        private ISayfaDal _dal { get; set; }
        public SayfaManager(ISayfaDal dal)
        {
            _dal = dal;
        }

        public SayfaEditDto Add(SayfaEditDto editDto)
        {
            Sayfa ent = Mapper.Map<Sayfa>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<SayfaEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<SayfaListDto> Get(Sayfa filter)
        {
            return Mapper.Map<List<Sayfa>, List<SayfaListDto>>(_dal.Get(filter));
        }

        public SayfaEditDto Get(int id)
        {
            return Mapper.Map<SayfaEditDto>(_dal.Get(id));
        }

        public SayfaEditDto Update(SayfaEditDto editDto)
        {
            Sayfa ent = Mapper.Map<Sayfa>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<SayfaEditDto>(_dal.Update(ent));
        }

        public SayfaDetailDto Get(EnuSayfaTipleri sayfaTipi)
        {
            return Mapper.Map<SayfaDetailDto>(_dal.Get(sayfaTipi));
        }
    }
}
