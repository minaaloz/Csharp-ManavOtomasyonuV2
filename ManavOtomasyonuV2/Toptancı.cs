using System;
using System.Collections.Generic;
using System.Text;

namespace ManavOtomasyonuV2
{
    class Toptanci
    {
        public Stok Meyveler { get; set; } = new Stok("meyve");
        public Stok Sebzeler { get; set; } = new Stok("sebze");

        public Toptanci()
        {
            Meyveler.Ekle("ELMA", 50);
            Meyveler.Ekle("ARMUT", 60);
            Meyveler.Ekle("KİRAZ", 20);

            Sebzeler.Ekle("PATLICAN", 60);
            Sebzeler.Ekle("SOĞAN", 60);
            Sebzeler.Ekle("PATATES", 50);
        }
    }
}
