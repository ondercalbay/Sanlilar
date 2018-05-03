﻿using AutoMapper;
using Sanlilar.DL.Abstract;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System;
using System.Collections.Generic;

namespace Sanlilar.BL
{
    public class UrunManager : IUrunManager
    {
        private IUrunDal _dal { get; set; }
        public int _userId { get; set; }
        public UrunManager(int userId, IUrunDal dal)
        {
            _userId = userId;
            _dal = dal;
        }

        public UrunEditDto Add(UrunEditDto editDto)
        {
            Urun ent = Mapper.Map<Urun>(editDto);
            ent.EkleyenId = _userId;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = _userId;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<UrunEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id, _userId);
        }

        public List<UrunListDto> Get(Urun filter)
        {
            return Mapper.Map<List<Urun>, List<UrunListDto>>(_dal.Get(filter));
        }

        public UrunEditDto Get(int id)
        {
            return Mapper.Map<UrunEditDto>(_dal.Get(id));
        }

        public UrunEditDto Update(UrunEditDto editDto)
        {
            Urun ent = Mapper.Map<Urun>(editDto);
            ent.EkleyenId = _userId;
            ent.EklemeZamani = DateTime.Now;

            return Mapper.Map<UrunEditDto>(_dal.Update(ent));
        }
    }
}