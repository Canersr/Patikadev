using System;

namespace KarakterCikartma
{
    class KarakterCikartici
    {
        public string Cikar(string metin, int index)
        {
            if (index < 0 || index >= metin.Length)
                return metin;

            return metin.Remove(index, 1);
        }
    }
}
