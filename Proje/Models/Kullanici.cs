using Microsoft.AspNetCore.Identity;


namespace Proje.Models
{
    public class Kullanici : IdentityUser
    {
        // Bu sınıfa özel başka özellikleri de ekleyebilirsiniz.
        // Örneğin, Adi, Soyadi gibi özellikleri burada bırakabilirsiniz.
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}
