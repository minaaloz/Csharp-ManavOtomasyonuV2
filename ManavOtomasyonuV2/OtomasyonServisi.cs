using ManavOtomasyonuV2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManavOtomasyonu
{
    class OtomasyonServisi
    {
        private Toptanci toptanci;
        private Manav manav;
        private Musteri musteri;

        public OtomasyonServisi(Toptanci toptanci, Manav manav, Musteri musteri)
        {
            this.toptanci = toptanci;
            this.manav = manav;
            this.musteri = musteri;
        }

        public void Calistir()
        {
            HalAlisverisi();

            if (!manav.UrunVarMi())
            {
                Console.WriteLine("Manavın toptancıdan aldığı ürün bulunmamaktadır.");
            }
            else
            {
                ManavAlisverisi();
                musteri.AlisverisListesiniYazdir();
            }
        }

        private void HalAlisverisi()
        {
            do
            {
                Console.WriteLine("\nHale hoşgeldiniz.");
                Console.WriteLine("Lütfen bir seçim yapınız, meyve için (M) Sebze için (S):");
                string secim = OkuMetin();

                if (GecerliSecimMi(secim))
                {
                    ToptancidanUrunAl(secim);
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            } while (DevamMi());
        }

        private void ToptancidanUrunAl(string secim)
        {
            Stok halStok = StokSec(toptanci.Meyveler, toptanci.Sebzeler, secim);
            Stok manavStok = StokSec(manav.Meyveler, manav.Sebzeler, secim);

            Console.WriteLine("\nToptancıdan " + halStok.Ad + " listesi:");
            halStok.Listele();

            Console.WriteLine("\nManavın almak istediği " + halStok.Ad + "yi giriniz:");
            string urunAdi = OkuMetin();
            int kg = OkuKg("Kaç kilo almak istiyorsunuz?");

            if (halStok.Cikar(urunAdi, kg))
            {
                manavStok.Ekle(urunAdi, kg);
                Console.WriteLine($"{urunAdi} {kg} - kg manavın {halStok.Ad}ler listesine eklendi.");
            }
            else
            {
                Console.WriteLine($"Toptancıda bu {halStok.Ad} yeteri kadar bulunmamaktadır / toptancı bu {halStok.Ad}yi satamamaktadır.");
            }
        }

        private void ManavAlisverisi()
        {
            while (true)
            {
                Console.WriteLine("\nMANAVA HOŞGELDİNİZ \nMeyve için M Sebze için S ye basınız.");
                string secim = OkuMetin();

                if (!GecerliSecimMi(secim))
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyiniz.");
                    continue;
                }

                Stok stok = StokSec(manav.Meyveler, manav.Sebzeler, secim);
                Console.WriteLine("\nManavın " + stok.Ad + " listesi:");
                stok.Listele();

                if (!MusteriUrunSatinAl())
                {
                    break;
                }
            }
        }
        private bool MusteriUrunSatinAl()
        {
            Console.WriteLine("\nMüşterinin almak istediği ürünü giriniz:");
            string urunAdi = OkuMetin();

            Stok stok;
            if (manav.Meyveler.VarMi(urunAdi))
            {
                stok = manav.Meyveler;
            }
            else if (manav.Sebzeler.VarMi(urunAdi))
            {
                stok = manav.Sebzeler;
            }
            else
            {
                Console.WriteLine("\nManavda bu ürün bulunmamaktadır.");
                return true;
            }

            int kg = OkuKg("Kaç kilo almak istiyorsunuz?");

            if (stok.Cikar(urunAdi, kg))
            {
                musteri.SepeteEkle(urunAdi, kg);
                Console.WriteLine($"{urunAdi} {kg} - kg aldınız.");
                return DevamMi();
            }
            else
            {
                Console.WriteLine("\nManavda bu ürün yeteri kadar bulunmamaktadır.");
                return false;
            }
        }

        private bool GecerliSecimMi(string secim)
        {
            return secim == "M" || secim == "S";
        }
        private Stok StokSec(Stok meyveler, Stok sebzeler, string secim)
        {
            if (secim == "M")
            {
                return meyveler;
            }
            else
            {
                return sebzeler;
            }
        }
        private string OkuMetin()
        {
            return Console.ReadLine().Trim().ToUpper();
        }
        private int OkuKg(string soru)
        {
            while (true)
            {
                Console.WriteLine(soru);
                int kg;
                if (int.TryParse(Console.ReadLine(), out kg) && kg > 0)
                {
                    return kg;
                }
                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
            }
        }
        private bool DevamMi()
        {
            Console.WriteLine("\nBaşka bir isteğiniz var mı? E/H");
            string cevap = OkuMetin();

            if (cevap == "E")
            {
                return true;
            }
            else if (cevap == "H")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Program sonlandırılıyor.");
                return false;
            }
        }
    }
}

