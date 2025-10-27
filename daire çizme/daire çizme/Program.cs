//using daire_çizme.Services;
using System;

namespace DaireCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            KullaniciGirdisi girdiler = new KullaniciGirdisi();
            DaireCizici cizici = new DaireCizici();

            int yaricap = girdiler.YaricapAl();
            Console.WriteLine("\nDaire çiziliyor...\n");
            cizici.Ciz(yaricap);

            Console.WriteLine("\nProgram tamamlandı.");
        }
    }
}
