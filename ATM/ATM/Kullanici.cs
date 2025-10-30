namespace ATMApp
{
    public class Kullanici
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public decimal Bakiye { get; set; }

        public Kullanici(string ad, string sifre, decimal bakiye = 1000)
        {
            KullaniciAdi = ad;
            Sifre = sifre;
            Bakiye = bakiye;
        }
    }
}
