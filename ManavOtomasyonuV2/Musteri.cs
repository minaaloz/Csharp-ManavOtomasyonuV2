using System;
using System.Collections.Generic;
using System.Text;

namespace ManavOtomasyonuV2
{
    class Musteri
    {
        public Stok Sepet { get; set; } = new Stok("sepet");

        public void SepeteEkle(string urunAdi, int kg)
        {
            Sepet.Ekle(urunAdi, kg);
        }

        public void AlisverisListesiniYazdir()
        {
            Console.WriteLine("\n MÜŞTERİNİN ALIŞVERİŞ LİSTESİ");
            Sepet.Listele();
        }
    }
}
