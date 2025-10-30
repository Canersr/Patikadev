using System;

namespace AlanHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            SekilSecici secici = new SekilSecici();

            Console.WriteLine("=== Geometrik Hesaplama Uygulaması ===\n");
            Console.Write("Hangi şekil için işlem yapmak istiyorsunuz? (Kare / Dikdörtgen / Daire / Üçgen): ");
            string sekilAdi = Console.ReadLine()?.Trim().ToLower();

            Sekil sekil = secici.SekilOlustur(sekilAdi);
            if (sekil == null)
            {
                Console.WriteLine("Geçersiz şekil girdiniz!");
                return;
            }

            sekil.KenarBilgileriniAl();

            Console.Write("Hangi işlemi yapmak istiyorsunuz? (Alan / Çevre): ");
            string islem = Console.ReadLine()?.Trim().ToLower();

            double sonuc = 0;

            if (islem == "alan")
                sonuc = sekil.AlanHesapla();
            else if (islem == "çevre" || islem == "cevre")
                sonuc = sekil.CevreHesapla();
            else
            {
                Console.WriteLine("Geçersiz işlem türü!");
                return;
            }

            Console.WriteLine($"\nSonuç: {sekil.GetType().Name} {islem} = {sonuc}");
        }
    }
}
