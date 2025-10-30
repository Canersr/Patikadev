using System;

namespace AlanHesaplama
{
    class Daire : Sekil
    {
        private double yaricap;

        public override void KenarBilgileriniAl()
        {
            Console.Write("Dairenin yarıçapını giriniz: ");
            yaricap = Convert.ToDouble(Console.ReadLine());
        }

        public override double AlanHesapla()
        {
            return Math.PI * yaricap * yaricap;
        }

        public override double CevreHesapla()
        {
            return 2 * Math.PI * yaricap;
        }
    }
}
