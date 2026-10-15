using ManavOtomasyonu;

namespace ManavOtomasyonuV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OtomasyonServisi servis = new OtomasyonServisi(new Toptanci(), new Manav(), new Musteri());
            servis.Calistir();
        }
    }
}
