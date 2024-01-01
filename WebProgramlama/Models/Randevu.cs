namespace WebProgramlama.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public string Aciklama { get; set; }

        // Diğer özellikler eklenebilir.

        // İlişki
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        public int UserId { get; set; }
        public Kullanici Kullanici { get; set; }
    }

}

/*
 * Bu örnekte Randevu sınıfına eklediğim özellikler şunlar:

Id: Randevunun benzersiz kimliğini temsil eder.
Tarih: Randevu tarihi.
Aciklama: Randevu ile ilgili kısa bir açıklama.
DoktorId ve Doktor: Randevunun hangi doktora ait olduğunu belirlemek için bir ilişki.
KullaniciId ve Kullanici: Randevunun hangi kullanıcıya ait olduğunu belirlemek için bir ilişki.
*/