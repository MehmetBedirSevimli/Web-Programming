namespace Proje.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public int KullaniciId { get; set; }
        public int DoktorId { get; set; }
        public int? PoliklinikId { get; set; }
        public DateTime Tarih { get; set; }
        public string? Durum { get; set; }
        public Kullanici? Kullanici { get; set; }
        public Doktor? Doktor { get; set; }
        public Poliklinik? Poliklinik { get; set;}
    }
}
