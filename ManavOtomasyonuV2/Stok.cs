using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ManavOtomasyonuV2
{
    class Stok
    {
        private ArrayList adlar = new ArrayList();
        private ArrayList kilolar = new ArrayList();
        public string Ad { get; set; }

        public Stok(string ad)
        {
            Ad = ad;
        }
        public int UrunSayisi()
        {
            return adlar.Count;
        }

        public bool VarMi(string urunAdi)
        {
            return adlar.Contains(urunAdi);
        }

        public void Ekle(string urunAdi, int kg)
        {
            if (adlar.Contains(urunAdi))
            {
                int sira = adlar.IndexOf(urunAdi);
                kilolar[sira] = (int)kilolar[sira] + kg;
            }
            else
            {
                adlar.Add(urunAdi);
                kilolar.Add(kg);
            }
        }

        public bool Cikar(string urunAdi, int kg)
        {
            if (!adlar.Contains(urunAdi))
            {
                return false;
            }

            int sira = adlar.IndexOf(urunAdi);
            if (kg > (int)kilolar[sira])
            {
                return false;
            }

            kilolar[sira] = (int)kilolar[sira] - kg;
            return true;
        }

        public void Listele()
        {
            for (int i = 0; i < adlar.Count; i++)
            {
                Console.WriteLine(adlar[i] + " - " + kilolar[i] + " kg");
            }
        }
    }
}
