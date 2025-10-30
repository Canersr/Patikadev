using System;

namespace KarakterTerstenYazdirma
{
    class Program
    {
        static void Main(string[] args)
        {
            GirdiIsleyici girdiler = new GirdiIsleyici();
            KarakterIsleyici isleyici = new KarakterIsleyici();

            Console.WriteLine("Lütfen kelimeleri boşlukla ayırarak giriniz (Örnek: Merhaba Hello Question):");
            string input = Console.ReadLine();

            string[] kelimeler = girdiler.KelimelereAyir(input);

            Console.WriteLine("\nÇıktı:");
            foreach (string kelime in kelimeler)
            {
                string sonuc = isleyici.KarakterleriKaydir(kelime);
                Console.WriteLine(sonuc);
            }
        }
    }
}
