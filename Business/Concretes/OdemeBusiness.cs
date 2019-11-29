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
        public Odeme AboneNoSec(int AboneNo)
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
                throw new Exception("OdemeBusiness:OdemeBusiness:Seçme Hatası", ex);
            }
        }
        public bool BorcOde(int AboneNo,string HesapNo)
        {
            var repo2 = new HesapRepository();
            try
            {
                using (var repo = new OdemeRepository())
                {
                    
                    Odeme o = repo.AboneNoSec(AboneNo);
                    Hesap h = repo2.HesapNoSec(HesapNo);
                    var bakiye = h.Bakiye;
                    var borc = o.Borc;
                    if (borc>0&&borc<= bakiye)
                    {
                        bakiye -= borc;
                        borc = 0;
                        repo2.HesapBakiyeGuncelle(h.HesapID, bakiye);
                        repo.BorcOde(AboneNo);
                        
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
