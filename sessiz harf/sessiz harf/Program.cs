using System;
using System.Linq;

namespace SessizKontrol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen kelimeleri boşlukla giriniz:");
            string input = Console.ReadLine();

            string[] kelimeler = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string kelime in kelimeler)
            {
                bool sonuc = YanYanaIkiSessizVarMi(kelime);
                Console.Write(sonuc + " ");
            }
        }

        static bool YanYanaIkiSessizVarMi(string kelime)
        {
            // Türkçedeki sesli harfler
            string sesliler = "aeıioöuüAEIİOÖUÜ";

            for (int i = 0; i < kelime.Length - 1; i++)
            {
                char c1 = kelime[i];
                char c2 = kelime[i + 1];

                // İki karakter de sessiz mi?
                if (!sesliler.Contains(c1) && !sesliler.Contains(c2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
