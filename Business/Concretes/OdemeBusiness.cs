using DataAccessLayer.Concretes;
using Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OdemeBusiness : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public OdemeBusiness()
        {

        }
        public Odeme AboneNoSec(string AboneNo)
        {
            try
            {
                Odeme responseEntitiy = null;
                using (var repo = new OdemeRepository())
                {
                    responseEntitiy = repo.AboneNoSec(AboneNo);

                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Seçme Hatası", ex);
            }
        }
        public bool BorcOde(string AboneNo)
        {
            var repo2 = new HesapRepository();
            try
            {
                using (var repo = new OdemeRepository())
                {
                    
                    Odeme o = repo.AboneNoSec(AboneNo);
                    Hesap h = repo2.MusterIDSec(o.MusteriID);

                    if (o.Borc>0&&o.Borc<=h.Bakiye)
                    {
                        h.Bakiye = h.Bakiye - o.Borc;
                        o.Borc = 0;
                        repo.BorcOde(o, 0);
                        repo2.HesapBakiyeGuncelle(h, h.Bakiye);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("OdemeBusiness:OdemeRepository:Ödeme Hatası", ex);
            }
        }
    }
}
