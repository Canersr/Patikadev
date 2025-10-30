

namespace AlanHesaplama
{
    class SekilSecici
    {
        public Sekil SekilOlustur(string sekilAdi)
        {
            switch (sekilAdi)
            {
                case "kare": return new Kare();
                case "dikdörtgen":
                case "dikdortgen": return new Dikdortgen();
                case "daire": return new Daire();
                case "üçgen":
                case "ucgen": return new Ucgen();
                default: return null;
            }
        }
    }
}
