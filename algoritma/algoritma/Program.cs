
using System;

namespace KarakterCikartma
{
    class Program
    {
        static void Main(string[] args)
        {
            GirdiIsleyici girdiler = new GirdiIsleyici();
            KarakterCikartici cikartici = new KarakterCikartici();

            Console.WriteLine("String ve index bilgisini virgülle giriniz (Örnek: Algoritma,3):");
            string input = Console.ReadLine();

            (string metin, int index) = girdiler.Ayrıştır(input);

            string sonuc = cikartici.Cikar(metin, index);

            Console.WriteLine("\nÇıktı: " + sonuc);
        }
    }
}
