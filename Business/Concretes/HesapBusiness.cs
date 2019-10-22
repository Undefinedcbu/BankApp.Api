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

        public Hesap HesapDurumGuncelle(int hesapId,bool durum)
        {
            try
            {
                using(var repo= new HesapRepository())
                {
                    Hesap h = repo.IdSec(hesapId);
                    if (repo.hesapIdGuncelle(h, durum))
                        return h;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Güncelleme Hatası", ex);
            }
        }

        public Hesap HesapEkle(Hesap entity,int MusteriID)
        {

            string hesap = MusteriID.ToString() + "00";
            try
            {
                using (var repo = new HesapRepository())
                {
                    if (repo.Ekle(entity,MusteriID,hesap))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Ekleme Hatası", ex);
            }
        }

        public Hesap HesapGoruntule(int musteriID)
        {
            try
            {
                Hesap responseEntitiy = null;
                using (var repo = new HesapRepository())
                {
                    responseEntitiy = repo.MusterIDSec(musteriID);

                }
                return responseEntitiy;
            }
            catch(Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRespository:Goruntuleme Hatası", ex);
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

        public bool Transfer(string GonderenHesapNo, string AlanHesapNo, decimal Miktar)
        {
            try
            {
                Hesap GonderenHesap = null;
                Hesap AlanHesap = null;
                using (var repo = new HesapRepository())
                {
                    GonderenHesap = repo.HesapNoSec(GonderenHesapNo);
                    if (GonderenHesap.Bakiye >= Miktar)
                    {
                        AlanHesap = repo.HesapNoSec(AlanHesapNo);
                        repo.HesapBakiyeGuncelle(GonderenHesap, GonderenHesap.Bakiye - Miktar);
                        repo.HesapBakiyeGuncelle(AlanHesap, AlanHesap.Bakiye + Miktar);
                        return true;
                    }
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("HesapBusiness:HesapRepository:Seçme Hatası", ex);
            }
        }
    }
}
