namespace WebProgramlama.Models
{
    public class RegisterViewModel
    {
        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Email { get; set; }

        public string Sifre { get; set; }

        // İhtiyaç duyulan diğer özellikleri ekleyebilirsiniz.

        // Örneğin, şifre tekrarını kontrol etmek için bir property ekleyebilirsiniz:
        // public string SifreTekrar { get; set; }
    }
}
