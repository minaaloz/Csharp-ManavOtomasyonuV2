using System;
using System.Collections.Generic;
using System.Text;

namespace ManavOtomasyonuV2
{
    class Manav
    {
        public Stok Meyveler { get; set; } = new Stok("meyve");
        public Stok Sebzeler { get; set; } = new Stok("sebze");

        public bool UrunVarMi()
        {
            return Meyveler.UrunSayisi() > 0 || Sebzeler.UrunSayisi() > 0;
        }
    }
}
