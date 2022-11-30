using Mulakat.Models;

namespace Mulakat.Services
{
    public class AnalysisService
    {
        Context c = new Context();
        public List<DtoSehirAnaliz> SehirBazliAnalizYap()
        {
            List<Musteri> musteriListesi = c.Musteris.ToList();
            List<Sepet> sepetListesi = c.Sepets.ToList();
            List<SepetUrun> sepetUrunListesi = c.SepetUruns.ToList();

            List<DtoSehirAnaliz> dtoSehirAnalizs = new List<DtoSehirAnaliz>();

            foreach (var musteri in musteriListesi)
            {
                DtoSehirAnaliz analiz = new DtoSehirAnaliz();
                int tutar = 0;
                int adet = 0;
                foreach (var sepet in sepetListesi)
                {
                    foreach(var sepetUrun in sepetUrunListesi)
                    {
                        if(musteri.MusteriID == sepet.MusteriID && sepet.SepetID == sepetUrun.SepetID)
                        {
                            tutar += sepetUrun.Tutar;
                        }
                    }
                    if(musteri.MusteriID == sepet.MusteriID)
                        adet += 1;
                }
                analiz.SehirAdi = musteri.Sehir;
                analiz.ToplamTutar = tutar;
                analiz.SepetAdet = adet;
                adet = 0;
                dtoSehirAnalizs.Add(analiz);
            }
            return dtoSehirAnalizs.OrderByDescending(x => x.SepetAdet).ToList();

        }
        



    }
}
