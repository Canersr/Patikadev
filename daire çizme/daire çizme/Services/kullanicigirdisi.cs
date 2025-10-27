using System;

namespace DaireCizme
{
    class KullaniciGirdisi
    {
        public int YaricapAl()
        {
            int r;
            while (true)
            {
                Console.Write("Dairenin yarıçapını giriniz: ");
                if (int.TryParse(Console.ReadLine(), out r) && r > 0)
                    return r;

                Console.WriteLine("Hatalı giriş! Lütfen pozitif bir sayı giriniz.\n");
            }
        }
    }
}
