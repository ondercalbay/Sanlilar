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
        public KullaniciSessionDto _user { get; set; }
        public SayfaManager(KullaniciSessionDto user, ISayfaDal dal)
        {
            _user = user;
            _dal = dal;
        }

        public SayfaEditDto Add(SayfaEditDto editDto)
        {
            Sayfa ent = Mapper.Map<Sayfa>(editDto);
            ent.EkleyenId = _user.Id;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = _user.Id;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<SayfaEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id, _user.Id);
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
            ent.GuncelleyenId = _user.Id;
            ent.GuncellemeZamani = DateTime.Now;
            return Mapper.Map<SayfaEditDto>(_dal.Update(ent));
        }

        public SayfaDetailDto Get(EnuSayfaTipleri sayfaTipi)
        {
            return Mapper.Map<SayfaDetailDto>(_dal.Get(sayfaTipi));
        }
    }
}
