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
        public int _userId { get; set; }
        public ResimManager(int userId, IResimDal dal)
        {
            _userId = userId;
            _dal = dal;
        }
        public ResimEditDto Add(ResimEditDto editDto)
        {
            Resim ent = Mapper.Map<Resim>(editDto);
            ent.EkleyenId = _userId;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = _userId;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<ResimEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id, _userId);
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
            ent.GuncelleyenId = _userId;
            ent.GuncellemeZamani = DateTime.Now;
          
            return Mapper.Map<ResimEditDto>(_dal.Update(ent));
        }
    }
}
