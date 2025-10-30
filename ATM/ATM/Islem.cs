using System;

namespace ATMApp
{
    public class Islem
    {
        public DateTime Tarih { get; set; }
        public string KullaniciAdi { get; set; }
        public string Tip { get; set; }
        public decimal Tutar { get; set; }

        public override string ToString()
        {
            return $"{Tarih:G} - {KullaniciAdi} - {Tip} - {Tutar} TL";
        }
    }
}
