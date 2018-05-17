using AutoMapper;
using Sanlilar.DL.Abstract;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System;
using System.Collections.Generic;

namespace Sanlilar.BL
{
    public class ResimManager : IResimManager
    {
        private IResimDal _dal { get; set; }
        public KullaniciSessionDto _user { get; set; }
        public ResimManager(KullaniciSessionDto user, IResimDal dal)
        {
            _user = user;
            _dal = dal;
        }
        public ResimEditDto Add(ResimEditDto editDto)
        {
            Resim ent = Mapper.Map<Resim>(editDto);
            ent.EkleyenId = _user.Id;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = _user.Id;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<ResimEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id, _user.Id);
        }

        public List<ResimListDto> Get(Resim filter)
        {
            return Mapper.Map<List<Resim>, List<ResimListDto>>(_dal.Get(filter));
        }

        public ResimEditDto Get(int id)
        {
            return Mapper.Map<ResimEditDto>(_dal.Get(id));
        }

        public ResimEditDto Update(ResimEditDto editDto)
        {
            Resim ent = Mapper.Map<Resim>(editDto);
            ent.GuncelleyenId = _user.Id;
            ent.GuncellemeZamani = DateTime.Now;
          
            return Mapper.Map<ResimEditDto>(_dal.Update(ent));
        }
    }
}
