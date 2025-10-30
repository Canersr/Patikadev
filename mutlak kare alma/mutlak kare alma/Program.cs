using System;
using System.Linq;

namespace MutlakKareAlma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen n adet tamsayıyı boşlukla giriniz:");
            string input = Console.ReadLine();

            int[] sayilar = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int farkToplami = 0;
            int kareToplami = 0;

            foreach (int sayi in sayilar)
            {
                int fark = Math.Abs(sayi - 67);

                if (sayi < 67)
                {
                    farkToplami += fark; // Küçük olanların farklarını topla
                }
                else if (sayi > 67)
                {
                    kareToplami += fark * fark; // Büyük olanların farklarının karelerini topla
                }
            }

            Console.WriteLine($"\nOutput: {farkToplami} {kareToplami}");
        }
    }
}
