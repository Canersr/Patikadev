using System;
using System.Collections.Generic;

namespace IkiliToplam
{
    class ToplamHesaplayici
    {
        public int[] Hesapla(int[] sayilar)
        {
            List<int> sonuc = new List<int>();

            for (int i = 0; i < sayilar.Length; i += 2)
            {
                int a = sayilar[i];
                int b = sayilar[i + 1];

                if (a == b)
                    sonuc.Add((a + b) * (a + b)); // Aynı ise toplamın karesi
                else
                    sonuc.Add(a + b); // Farklı ise toplam
            }

            return sonuc.ToArray();
        }
    }
}
