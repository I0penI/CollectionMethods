using System.Globalization;
using OgrenciSorgulama.Models;
using OgrenciSorgulama.Services;

namespace OgrenciSorgulama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OgrenciService servis = new OgrenciService();
            Ogrenci ogrenci;
            Ogrenci bulunanOgrenci;
            string mezun, giris;
            servis.OgrenciDataOlustur();
            

            Console.Write("Öğrenci Adı (Çıkış İçin: ç ): ");
            giris = Console.ReadLine().ToUpper().Trim();
            while (giris != "Ç")
            {
                ogrenci = new Ogrenci();
                ogrenci.Adi = giris;
                Console.Write("Öğrenci Soyadı: ");
                ogrenci.Soyadi = Console.ReadLine().ToUpper().Trim();
                Console.Write("Öğrenci Doğum Tarihi (gg.aa.yyyy): ");
                ogrenci.DogumTarihi = DateTime.Parse(Console.ReadLine(), new CultureInfo("tr-TR"));
                Console.Write("Öğrenci Mezuniyet Durumu (m: mezun, d: mezun değil): ");
                mezun = Console.ReadLine().ToLower().Trim();
                ogrenci.MezunMu = mezun == "m";
                servis.OgrenciEkle(ogrenci);
                Console.Write("Öğrenci Adı (Çıkış İçin: ç ): ");
                giris = Console.ReadLine().ToUpper().Trim();
            }

            List<Ogrenci> ogrenciler = servis.OgrencileriGetir();
            Console.WriteLine("Öğrenciler: ");
            foreach (Ogrenci o in ogrenciler)
            {
                Console.WriteLine($"Id: {o.Id}, Adı: {o.Adi}, Soyadı: {o.Soyadi}, Doğum Tarihi: {o.DogumTarihi.ToString("dd.MM.yyyy")}, Mezuniyet Durumu: {(o.MezunMu ? "Mezun" :  "Mezun Değil" )}");
            }

            Console.Write("Aramak İstediğiniz Öğrencinin Adını Ve Soyadını Giriniz (çıkış: ç): ");
            giris = Console.ReadLine().ToUpper().Trim();
            while (giris != "Ç")
            {
               bulunanOgrenci = servis.OgrenciGetir(giris);
               // if(bulunanOgrenci == null) alt satırla aynı işi yapar
                if(bulunanOgrenci is null)
                    Console.WriteLine("Öğrenci Bulunamadı!");
                else// bulunan öğrenci is not null
                    Console.WriteLine($"Id: {bulunanOgrenci.Id}, Adı: {bulunanOgrenci.Adi}, Soyadı: {bulunanOgrenci.Soyadi}, Doğum Tarihi: {bulunanOgrenci.DogumTarihi.ToString("dd.MM.yyyy")}, Mezuniyet Durumu: {(bulunanOgrenci.MezunMu ? "Mezun" : "Mezun Değil")}");
                Console.Write("Aramak İstediğiniz Öğrencinin Adını Ve Soyadını Giriniz (çıkış: ç): ");
                giris = Console.ReadLine().ToUpper().Trim();
            }

            Console.Write("Silmek istediğiniz öğrencinin ID'sini giriniz (çıkış: ç): ");
            giris = Console.ReadLine().ToUpper().Trim();
            while (giris != "Ç")
            {
                int id = servis.OgrenciSil(giris);
                if(id >0);
                Console.WriteLine($"{id} ID'li Öğrenci silindi.");
                Console.Write("Silmek istediğiniz öğrencinin ID'sini giriniz (çıkış: ç): ");
                giris = Console.ReadLine().ToUpper().Trim();
            }
            ogrenciler = servis.OgrencileriGetir();
            Console.WriteLine("Öğrenciler: ");
            foreach (Ogrenci o in ogrenciler)
            {
                Console.WriteLine($"Id: {o.Id}, Adı: {o.Adi}, Soyadı: {o.Soyadi}, Doğum Tarihi: {o.DogumTarihi.ToString("dd.MM.yyyy")}, Mezuniyet Durumu: {(o.MezunMu ? "Mezun" : "Mezun Değil")}");
            }
        }
    }

}