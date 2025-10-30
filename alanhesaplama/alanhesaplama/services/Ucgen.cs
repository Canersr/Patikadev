using System;

namespace AlanHesaplama
{
    class Ucgen : Sekil
    {
        private double a, b, c, h;

        public override void KenarBilgileriniAl()
        {
            Console.Write("Birinci kenarı giriniz: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci kenarı giriniz: ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Üçüncü kenarı giriniz: ");
            c = Convert.ToDouble(Console.ReadLine());

            Console.Write("Taban yüksekliğini giriniz (alan için): ");
            h = Convert.ToDouble(Console.ReadLine());
        }

        public override double AlanHesapla()
        {
            return (a * h) / 2;
        }

        public override double CevreHesapla()
        {
            return a + b + c;
        }
    }
}
