﻿using AutoMapper;
using Sanlilar.DL.Abstract;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sanlilar.BL
{
    public class KategoriManager : IKategoriManager
    {
        private IKategoriDal _dal { get; set; }
        public int _userId { get; set; }
        public KategoriManager(int userId,IKategoriDal dal)
        {
            _userId = userId;
            _dal = dal;
        }

        public KategoriEditDto Add(KategoriEditDto editDto)
        {
            Kategori ent = Mapper.Map<Kategori>(editDto);
            ent.EkleyenId = _userId;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = _userId;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<KategoriEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id,_userId);
        }

        public List<KategoriListDto> Get(Kategori filter)
        {
            var kategoriler = _dal.Get(filter);
            var query = kategoriler.Select(i =>
                 new KategoriListDto
                 {
                     Adi = i.Adi,
                     UstKategoriAdi = Get(i.UstKategoriId).Adi,
                     Id = i.Id
                 }
                );
            return query.ToList();
        }

        public KategoriEditDto Get(int id)
        {
            return Mapper.Map<KategoriEditDto>(_dal.Get(id));
        }

        public KategoriEditDto Update(KategoriEditDto editDto)
        {
            Kategori ent = Mapper.Map<Kategori>(editDto);
            ent.GuncelleyenId = _userId;
            ent.GuncellemeZamani = DateTime.Now;
            return Mapper.Map<KategoriEditDto>(_dal.Update(ent));
        }

        public KategoriEditDto Get(int? id)
        {
            if (id == null)
            {
                return new KategoriEditDto();
            }
            else
            {
                int i = Convert.ToInt32(id.ToString());
                return Mapper.Map<KategoriEditDto>(_dal.Get(i));
            }
            


        }
    }
}
