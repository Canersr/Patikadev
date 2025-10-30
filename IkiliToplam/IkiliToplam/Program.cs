using System;

namespace IkiliToplam
{
    class Program
    {
        static void Main(string[] args)
        {
            ToplamHesaplayici hesaplayici = new ToplamHesaplayici();
            GirdiIsleyici girdiler = new GirdiIsleyici();

            // GirdiIsleyici kendi içinde kullanıcıdan sayıları alıyor
            int[] sayilar = girdiler.SayilaraDonustur();

            int[] sonuc = hesaplayici.Hesapla(sayilar);

            Console.WriteLine("\nÇıktı:");
            Console.WriteLine(string.Join(" ", sonuc));
        }
    }
}
