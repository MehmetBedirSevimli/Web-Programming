namespace WebProgramlama.Models
{
    public class Doktor
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Unvan { get; set; }

        public string Aciklama { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

        // Diğer özellikler eklenebilir.

        // İlişki
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<CalismaSaatleri> CalismaSaatleri { get; set; }

    }

}

/*Bu örnekte Doktor sınıfına eklediğim özellikler şunlar:

Id: Doktorun benzersiz kimliğini temsil eder.
Adi ve Soyadi: Doktorun adını ve soyadını temsil eder.
Unvan: Doktorun unvanını temsil eder (örneğin, Prof. Dr., Dr., Uzm. Dr. vb.).
Aciklama: Doktor hakkında kısa bir açıklama içerir.
Email: Doktorun iletişim bilgilerinden biri olan e-posta adresini temsil eder.
Telefon: Doktorun iletişim bilgilerinden biri olan telefon numarasını temsil eder.
PoliklinikId ve Poliklinik: Doktorun hangi polikliniğe bağlı olduğunu belirlemek için bir ilişki tanımlanmıştır.
Randevular: Doktor ile ilişkilendirilmiş randevuları içerir.
*/