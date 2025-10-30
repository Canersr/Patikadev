using System;
using System.Linq;

namespace KarakterDegistirme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen kelimeleri boşlukla giriniz:");
            string input = Console.ReadLine();

            string[] kelimeler = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] sonuc = kelimeler.Select(KarakterDegistir).ToArray();

            Console.WriteLine("\nOutput:");
            Console.WriteLine(string.Join(" ", sonuc));
        }

        static string KarakterDegistir(string kelime)
        {
            if (kelime.Length <= 1)
                return kelime; // tek karakterliyse değiştirme

            char ilk = kelime[0];
            char son = kelime[kelime.Length - 1];

            // Aradaki kısmı koruyarak ilk ve sonu değiştir
            string ortasi = kelime.Substring(1, kelime.Length - 2);
            return son + ortasi + ilk;
        }
    }
}
