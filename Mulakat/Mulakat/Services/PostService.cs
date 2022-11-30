using Microsoft.Extensions.WebEncoders.Testing;
using Mulakat.Models;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;

namespace Mulakat.Services
{
    
    public class PostService
    {
        Random rnd = new Random();
        Context c = new Context();

        //public int PostSum(int a, int b)
        //{
        //    return a + b;

        //}

        public List<Musteri> TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            List<Musteri> musteriListesi = new List<Musteri>();
            List<Sepet> sepetListesi = new List<Sepet>();
            List<SepetUrun> sepetUrunListesi = new List<SepetUrun>();

            for(int i=0;i<musteriAdet;i++)
            {
                musteriListesi.Add(YeniMusteri());
            }
            c.Musteris.AddRange(musteriListesi);
            c.SaveChanges();

            for (int i = 0; i < sepetAdet; i++)
            {
                Musteri musteri = new Musteri();
                musteri = musteriListesi[randomSayi(0,musteriListesi.Count)];
                sepetListesi.Add(YeniSepet(musteri));
            }
            c.Sepets.AddRange(sepetListesi);
            c.SaveChanges();

            foreach(var sepet in sepetListesi)
            {
                int urunAdet = randomSayi(1, 6);
                for(int i=0; i<urunAdet; i++)
                {
                    sepetUrunListesi.Add(YeniUrun(sepet));
                }
            }
            c.SepetUruns.AddRange(sepetUrunListesi);
            c.SaveChanges();



            return musteriListesi;

        }

        private Musteri YeniMusteri()
        {
            Musteri musteri = new Musteri();
            musteri.Ad = randomString(5);
            musteri.Soyad = randomString(5);
            musteri.Sehir = randomSehir();
            return musteri;
        }

        private Sepet YeniSepet(Musteri musteri)
        {
            Sepet sepet = new Sepet();
            sepet.MusteriID = musteri.MusteriID;
            return sepet;
        }

        private SepetUrun YeniUrun(Sepet sepet)
        {
            SepetUrun sepetUrun = new SepetUrun();
            sepetUrun.Tutar = randomSayi(100, 1000);
            sepetUrun.Aciklama = randomString(20);
            sepetUrun.SepetID = sepet.SepetID;
            return sepetUrun;
        }

        private int randomSayi(int a , int b)
        {
            return rnd.Next(a, b);
        }
        private string randomString(int a)
        {
            string metin = "";

            for(int i=0; i<a; i++)
            {
                metin += Convert.ToChar(randomSayi(65,91));
            }
            return metin;
        }
        private string randomSehir()
        {
            string[] Sehirler = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };
            return Sehirler[randomSayi(0,Sehirler.Length)];
        }
    }
}
