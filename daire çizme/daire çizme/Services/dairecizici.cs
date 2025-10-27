using System;

namespace DaireCizme
{
    class DaireCizici
    {
        public void Ciz(int r)
        {
            double kalinlik = 0.4; // Dairenin dış çizgisini biraz kalın göstermek için
            double rIn = r - kalinlik;
            double rOut = r + kalinlik;

            for (int y = r; y >= -r; y--)
            {
                for (int x = -r; x <= r; x++)
                {
                    double deger = x * x + y * y;
                    if (deger >= rIn * rIn && deger <= rOut * rOut)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
