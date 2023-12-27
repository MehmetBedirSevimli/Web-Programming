namespace Proje.Models
{
    public class Poliklinik
    {
        public int PoliklinikId { get; set; }
        public string Adi { get; set; }
        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }
    }
}
