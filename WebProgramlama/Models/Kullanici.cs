namespace WebProgramlama.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Email { get; set; }

        public string Sifre { get; set; }

        // Diğer özellikler eklenebilir.

        // İlişki
        public ICollection<Randevu> Randevular { get; set; }
    }

}
/*
 * Bu örnekte Kullanici sınıfına eklediğim özellikler şunlar:

Id: Kullanıcının benzersiz kimliğini temsil eder.
Adi ve Soyadi: Kullanıcının adını ve soyadını temsil eder.
Email: Kullanıcının iletişim bilgilerinden biri olan e-posta adresini temsil eder.
Sifre: Kullanıcının şifresini temsil eder (güvenlik nedeniyle şifreleri açıkça saklamamalısınız, bu sadece bir örnek).
Randevular: Kullanıcı ile ilişkilendirilmiş randevuları içerir.
*/
