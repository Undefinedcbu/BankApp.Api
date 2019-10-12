using Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concretes;

namespace Business.Concretes
{
    public class HesapBusiness : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public HesapBusiness()
        {

        }
        public Hesap HesapEkle(Hesap entity)
        {
            try
            {
                using (var repo = new HesapRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Ekleme Hatası", ex);
            }
        }
        public Hesap HesapGuncelle(Hesap entity)
        {
            try
            {
                using (var repo = new HesapRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Güncelleme Hatası", ex);
            }
        }
        public Hesap HesapIdSec(int HesapId)
        {
            try
            {
                Hesap responseEntitiy = null;
                using (var repo = new HesapRepository())
                {
                    responseEntitiy = repo.IdSec(HesapId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Seçme Hatası", ex);
            }
        }
    }
}
