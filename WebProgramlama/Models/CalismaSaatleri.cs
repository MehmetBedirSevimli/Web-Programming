namespace WebProgramlama.Models
{
    public class CalismaSaatleri
    {
        public int Id { get; set; }
        public int DoktorId { get; set; }  // Doktor ile ilişkilendirme
        public string Gun { get; set; }   // Pazartesi, Salı, vs.
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
    }

}
