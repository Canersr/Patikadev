using System;

namespace KarakterCikartma
{
    class GirdiIsleyici
    {
        public (string, int) Ayrıştır(string input)
        {
            string[] parcalar = input.Split(',');
            if (parcalar.Length != 2)
                throw new ArgumentException("Girdi doğru formatta değil! Örnek: Algoritma,3");

            string metin = parcalar[0];
            int index = int.TryParse(parcalar[1], out int i) ? i : -1;

            if (index < 0 || index >= metin.Length)
            {
                Console.WriteLine("Index string uzunluğunun dışında, karakter çıkarılamıyor.");
                return (metin, -1);
            }

            return (metin, index);
        }
    }
}
