using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Concretes
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string TcKimlik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public Guid Anahtar { get; set; }
        public List<Hesap> Hesaplar { get; set; }
    }
}

