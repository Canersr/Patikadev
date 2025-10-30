using System;

namespace KarakterTerstenYazdirma
{
    class KarakterIsleyici
    {
        public string KarakterleriKaydir(string kelime)
        {
            if (string.IsNullOrEmpty(kelime) || kelime.Length == 1)
                return kelime;

            // İlk karakteri sona taşı, geri kalanı öne kaydır
            string yeniKelime = kelime.Substring(1) + kelime[0];
            return yeniKelime;
        }
    }
}
