using System;

namespace AlanHesaplama
{
    class Kare : Sekil
    {
        private double kenar;

        public override void KenarBilgileriniAl()
        {
            Console.Write("Karenin kenar uzunluğunu giriniz: ");
            kenar = Convert.ToDouble(Console.ReadLine());
        }

        public override double AlanHesapla()
        {
            return kenar * kenar;
        }

        public override double CevreHesapla()
        {
            return 4 * kenar;
        }
    }
}
