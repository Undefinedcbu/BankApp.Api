using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Concretes
{
   public class Hesap
    {
        public int HesapID { get; set; }
        public int MusteriID { get; set; }
        public decimal Bakiye { get; set; }
        public int EkNo { get; set; }
        public string HesapNo { get; set; }
        public bool Durum { get; set; }
    }
}
