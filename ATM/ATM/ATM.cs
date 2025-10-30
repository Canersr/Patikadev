using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ATMApp
{
    public class ATM
    {
        private List<Kullanici> kullanicilar = new List<Kullanici>();
        private List<Islem> islemler = new List<Islem>();
        private List<string> hataliGirisler = new List<string>();

        public ATM()
        {
            // Örnek kullanıcılar
            kullanicilar.Add(new Kullanici("caner", "1234"));
            kullanicilar.Add(new Kullanici("admin", "0000"));
        }

        public void Baslat()
        {
            Console.WriteLine("ATM Uygulamasına Hoşgeldiniz!");
            Console.WriteLine("-------------------------------");

            while (true)
            {
                Console.Write("Kullanıcı adınızı giriniz: ");
                string ad = Console.ReadLine();
                Console.Write("Şifrenizi giriniz: ");
                string sifre = Console.ReadLine();

                Kullanici kullanici = GirisYap(ad, sifre);
                if (kullanici != null)
                {
                    IslemleriGoster(kullanici);
                }
                else
                {
                    Console.WriteLine("Giriş başarısız! Kayıt olmak ister misiniz? (E/H)");
                    string cevap = Console.ReadLine().ToLower();
                    if (cevap == "e")
                    {
                        KayitOl();
                    }
                    else
                    {
                        hataliGirisler.Add($"{DateTime.Now:G} - Hatalı giriş: {ad}");
                    }
                }

                Console.Write("\nYeni işlem yapmak ister misiniz? (E/H): ");
                if (Console.ReadLine().ToLower() != "e")
                {
                    GunSonuAl();
                    break;
                }
            }
        }

        private Kullanici GirisYap(string ad, string sifre)
        {
            return kullanicilar.FirstOrDefault(k => k.KullaniciAdi == ad && k.Sifre == sifre);
        }

        private void KayitOl()
        {
            Console.Write("Yeni kullanıcı adı: ");
            string ad = Console.ReadLine();

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            kullanicilar.Add(new Kullanici(ad, sifre));
            Console.WriteLine("Kayıt başarılı! Artık giriş yapabilirsiniz.");
        }

        private void IslemleriGoster(Kullanici kullanici)
        {
            while (true)
            {
                Console.WriteLine("\n1- Para Çekme");
                Console.WriteLine("2- Para Yatırma");
                Console.WriteLine("3- Bakiye Görüntüleme");
                Console.WriteLine("4- Ödeme Yap");
                Console.WriteLine("5- Gün Sonu Al ve Çık");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": ParaCek(kullanici); break;
                    case "2": ParaYatir(kullanici); break;
                    case "3": Console.WriteLine($"Mevcut bakiyeniz: {kullanici.Bakiye} TL"); break;
                    case "4": OdemeYap(kullanici); break;
                    case "5": GunSonuAl(); Environment.Exit(0); break;
                    default: Console.WriteLine("Geçersiz seçim!"); break;
                }
            }
        }

        private void ParaCek(Kullanici kullanici)
        {
            Console.Write("Çekmek istediğiniz tutar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal tutar) && tutar > 0)
            {
                if (tutar <= kullanici.Bakiye)
                {
                    kullanici.Bakiye -= tutar;
                    islemler.Add(new Islem { Tarih = DateTime.Now, KullaniciAdi = kullanici.KullaniciAdi, Tip = "Para Çekme", Tutar = tutar });
                    Console.WriteLine("İşlem başarılı!");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz tutar!");
            }
        }

        private void ParaYatir(Kullanici kullanici)
        {
            Console.Write("Yatırmak istediğiniz tutar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal tutar) && tutar > 0)
            {
                kullanici.Bakiye += tutar;
                islemler.Add(new Islem { Tarih = DateTime.Now, KullaniciAdi = kullanici.KullaniciAdi, Tip = "Para Yatırma", Tutar = tutar });
                Console.WriteLine("İşlem başarılı!");
            }
            else
            {
                Console.WriteLine("Geçersiz tutar!");
            }
        }

        private void OdemeYap(Kullanici kullanici)
        {
            Console.Write("Ödeme miktarı: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal tutar) && tutar > 0)
            {
                if (tutar <= kullanici.Bakiye)
                {
                    kullanici.Bakiye -= tutar;
                    islemler.Add(new Islem { Tarih = DateTime.Now, KullaniciAdi = kullanici.KullaniciAdi, Tip = "Ödeme", Tutar = tutar });
                    Console.WriteLine("Ödeme tamamlandı.");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz tutar!");
            }
        }

        private void GunSonuAl()
        {
            string dosyaAdi = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
            string klasorYolu = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(klasorYolu);

            string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

            using (StreamWriter writer = new StreamWriter(dosyaYolu))
            {
                writer.WriteLine("=== GÜN SONU RAPORU ===");
                writer.WriteLine($"Tarih: {DateTime.Now:G}");
                writer.WriteLine("\n--- Gerçekleşen İşlemler ---");
                foreach (var islem in islemler)
                {
                    writer.WriteLine(islem);
                }

                writer.WriteLine("\n--- Hatalı Girişler ---");
                foreach (var hata in hataliGirisler)
                {
                    writer.WriteLine(hata);
                }
            }

            Console.WriteLine($"\nGün sonu raporu oluşturuldu: {dosyaAdi}");
        }
    }
}
