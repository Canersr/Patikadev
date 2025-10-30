using System;

namespace KarakterTerstenYazdirma
{
    class GirdiIsleyici
    {
        public string[] KelimelereAyir(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Boş bir ifade girdiniz!");

            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
