using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciOrtalama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fibonacci serisinin derinliğini giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int derinlik) && derinlik > 0)
            {
                FibonacciService fibonacciService = new FibonacciService();
                OrtalamaHesaplayici ortalamaHesaplayici = new OrtalamaHesaplayici();

                var seri = fibonacciService.FibonacciOlustur(derinlik);
                double ortalama = ortalamaHesaplayici.OrtalamaHesapla(seri);

                Console.WriteLine("\nFibonacci Serisi: " + string.Join(", ", seri));
                Console.WriteLine($"Ortalama: {ortalama:F2}");
            }
            else
            {
                Console.WriteLine("Lütfen pozitif bir tam sayı giriniz.");
            }

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basınız...");
            Console.ReadKey();
        }
    }

    // -----------------------------
    // FIBONACCI SERVİSİ
    // -----------------------------
    public class FibonacciService
    {
        public List<int> FibonacciOlustur(int n)
        {
            List<int> seri = new List<int>();
            int a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                seri.Add(a);
                int temp = a + b;
                a = b;
                b = temp;
            }

            return seri;
        }
    }

    // -----------------------------
    // ORTALAMA HESAPLAYICI
    // -----------------------------
    public class OrtalamaHesaplayici
    {
        public double OrtalamaHesapla(List<int> sayilar)
        {
            if (sayilar == null || sayilar.Count == 0)
                return 0;

            return sayilar.Average();
        }
    }
}
