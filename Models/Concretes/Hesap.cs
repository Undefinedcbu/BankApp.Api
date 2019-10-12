using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Concretes
{
    class Hesap
    {
        public int HesapID { get; set; }
        public int MusteriID { get; set; }
        public decimal Bakiye { get; set; }
        public string EkNo { get; set; }
        public string HesapNo { get; set; }
        public bool Durum { get; set; }
    }
}
