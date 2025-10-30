using System;

namespace AlanHesaplama
{
    class Dikdortgen : Sekil
    {
        private double kisaKenar;
        private double uzunKenar;

        public override void KenarBilgileriniAl()
        {
            Console.Write("Kısa kenarı giriniz: ");
            kisaKenar = Convert.ToDouble(Console.ReadLine());

            Console.Write("Uzun kenarı giriniz: ");
            uzunKenar = Convert.ToDouble(Console.ReadLine());
        }

        public override double AlanHesapla()
        {
            return kisaKenar * uzunKenar;
        }

        public override double CevreHesapla()
        {
            return 2 * (kisaKenar + uzunKenar);
        }
    }
}
