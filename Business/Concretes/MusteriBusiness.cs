using BankApp.Concretes;
using Models.Concretes;
using System;
using System.Collections.Generic;

namespace Business
{
    public class MusteriBusiness : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public MusteriBusiness()
        {

        }
        public IList<Musteri> TumMusteriler()
        {
            IList<Musteri> musteriler;

            try
            {
                using (var repo = new MusteriRepository())
                {
                    musteriler = repo.HepsiniSec();
                }
                return musteriler;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Musteri Giris(string TCKimlik, string parola)
        {
            Musteri Musteri = null;
            try
            {
                using (var repo = new MusteriRepository())
                {
                    Musteri = repo.Giris(TCKimlik, parola);
                }
                return Musteri;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Musteri MusteriSecIsim(string MusteriAdi)
        {
            try
            {
                Musteri responseEntitiy = null;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.MusteriAdSec(MusteriAdi);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:MusteriAdi Seçme Hatası", ex);
            }
        }
        public Musteri MusteriTCSec(string TCKimlik)
        {
            try
            {
                Musteri responseEntitiy = null;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.TCSec(TCKimlik);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Seçme Hatası", ex);
            }
        }
        public Musteri MusteriIdSec(int MusteriId)
        {
            try
            {
                Musteri responseEntitiy = null;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.IdSec(MusteriId);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Seçme Hatası", ex);
            }
        }

        public Musteri MusteriAnahtarSec(string Anahtar)
        {

            try
            {
                Musteri responseEntitiy = null;
                using (var repo = new MusteriRepository())
                {
                    responseEntitiy = repo.KeySec(Anahtar);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Key Seçme Hatası", ex);
            }
        }
        public Musteri MusteriEkle(Musteri entity)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.Ekle(entity))
                        return entity;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Ekleme Hatası", ex);
            }
        }

        public Musteri MusteriGuncelle(Musteri entity)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.Guncelle(entity))
                        return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Güncelleme Hatası", ex);
            }
        }

        public Musteri MusteriIdSil(int MusteriId)
        {
            try
            {
                using (var repo = new MusteriRepository())
                {
                    if (repo.IdSil(MusteriId))
                        return repo.IdSec(MusteriId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("MusteriBusiness:MusteriRepository:Silme Hatası", ex);
            }
        }

        




    }
}
