using AutoMapper;
using Sanlilar.DL.Abstract;
using Sanlilar.Dto;
using Sanlilar.Entity;
using Sanlilar.IL;
using System;
using System.Collections.Generic;

namespace Sanlilar.BL
{
    public class KategoriManager : IKategoriManager
    {
        private IKategoriDal _dal { get; set; }
        public KategoriManager(IKategoriDal dal)
        {
            _dal = dal;
        }
        public KategoriEditDto Add(KategoriEditDto editDto)
        {
            Kategori ent = Mapper.Map<Kategori>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<KategoriEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<KategoriListDto> Get(Kategori filter)
        {
            return Mapper.Map<List<KategoriListDto>>(_dal.Get(filter));
        }

        public KategoriEditDto Get(int id)
        {
            return Mapper.Map<KategoriEditDto>(_dal.Get(id));
        }

        public KategoriEditDto Update(KategoriEditDto editDto)
        {
            Kategori ent = Mapper.Map<Kategori>(editDto);
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            return Mapper.Map<KategoriEditDto>(_dal.Update(ent));
        }
    }
}
