using OgrenciSorgulama.Data;
using OgrenciSorgulama.Models;

namespace OgrenciSorgulama.Services
{
    internal class OgrenciService
    {


        public void OgrenciDataOlustur()
        {
            OgrenciData.Ogrenciler = new List<Ogrenci>();

        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            if (OgrenciData.Ogrenciler.Count > 0)
                ogrenci.Id = OgrenciData.Ogrenciler[OgrenciData.Ogrenciler.Count - 1].Id + 1;
            else
                ogrenci.Id = 1;
            OgrenciData.Ogrenciler.Add(ogrenci);
        }

        public List<Ogrenci> OgrencileriGetir()
        {
            return OgrenciData.Ogrenciler;
        }

        public Ogrenci OgrenciGetir(string tamAd)
        {
            Ogrenci ogrenci = null;
            foreach (Ogrenci o in OgrenciData.Ogrenciler)
            {
                if (o.Adi + " " + o.Soyadi == tamAd)
                {
                    ogrenci = o;
                    break;
                }
            }
            return ogrenci;
        }

        public Ogrenci OgrenciGetir(int id)
        {
            Ogrenci ogrenci = null;
            foreach (Ogrenci o in OgrenciData.Ogrenciler)
            {
                if (o.Id == id)
                {
                    ogrenci = o;
                    break;
                }
            }
            return ogrenci;
        }

        public int OgrenciSil(string id)
        {
            Ogrenci ogrenci = OgrenciGetir(Convert.ToInt32(id));
            if (ogrenci is null)
                return 0;
            OgrenciData.Ogrenciler.Remove(ogrenci);
            return ogrenci.Id;
        }
    }
}
