using System;

namespace UcgenCizme
{
    // Sorumluluk 1: Kullanıcıdan veri almak
    class KullaniciGirdisi
    {
        public int BoyutAl()
        {
            int boyut;
            while (true)
            {
                Console.Write("Üçgenin boyutunu giriniz: ");
                if (int.TryParse(Console.ReadLine(), out boyut) && boyut > 0)
                    return boyut;

                Console.WriteLine("Hatalı giriş! Lütfen pozitif bir sayı giriniz.\n");
            }
        }
    }

    // Sorumluluk 2: Üçgeni çizmek
    class UcgenCizici
    {
        public void Ciz(int boyut)
        {
            for (int i = 1; i <= boyut; i++)
            {
                string satir = SatirOlustur(boyut, i);
                Console.WriteLine(satir);
            }
        }

        private string SatirOlustur(int boyut, int satirNo)
        {
            int boslukSayisi = boyut - satirNo;
            int yildizSayisi = satirNo * 2 - 1;

            string bosluk = new string(' ', boslukSayisi);
            string yildizlar = new string('*', yildizSayisi);

            return bosluk + yildizlar + bosluk;
        }
    }

    // Sorumluluk 3: Uygulamayı başlatmak
    class Program
    {
        static void Main(string[] args)
        {
            KullaniciGirdisi girdiler = new KullaniciGirdisi();
            UcgenCizici cizici = new UcgenCizici();

            int boyut = girdiler.BoyutAl();
            Console.WriteLine("\nÜçgen Çiziliyor...\n");
            cizici.Ciz(boyut);

            Console.WriteLine("\nProgram tamamlandı.");
        }
    }
}
