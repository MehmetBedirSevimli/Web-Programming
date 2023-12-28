namespace Proje.Models
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public List<WorkingHours> WorkingHours { get; set; }
    }
}
