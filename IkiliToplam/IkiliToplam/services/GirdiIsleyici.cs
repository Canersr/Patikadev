using System;
using System.Linq;

namespace IkiliToplam
{
    class GirdiIsleyici
    {
        public int[] SayilaraDonustur()
        {
            while (true)
            {
                Console.WriteLine("Lütfen n adet tamsayıyı boşlukla giriniz:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Boş giriş yapamazsınız!");
                    continue;
                }

                int[] sayilar;
                try
                {
                    sayilar = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s =>
                        {
                            if (int.TryParse(s, out int deger))
                                return deger;
                            else
                                throw new ArgumentException($"Geçersiz sayı girdiniz: {s}");
                        })
                        .ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                if (sayilar.Length < 2)
                {
                    Console.WriteLine("En az iki sayı girmeniz gerekiyor!");
                    continue;
                }

                if (sayilar.Length % 2 != 0)
                {
                    Console.WriteLine("Sayı adedi tek, son sayı işleme alınmayacak.");
                    sayilar = sayilar.Take(sayilar.Length - 1).ToArray();
                }

                return sayilar;
            }
        }
    }
}
