namespace WebProgramlama.Models
{
    public class Poliklinik
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Aciklama { get; set; }

        // Diğer özellikler eklenebilir.

        // İlişki
        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }

        public ICollection<Doktor> Doktorlar { get; set; }
    }

}

/* Bu örnekte Poliklinik sınıfına eklediğim özellikler şunlar:

Id: Polikliniğin benzersiz kimliğini temsil eder.
Adi: Polikliniğin adını temsil eder.
Aciklama: Polikliniğin kısa bir açıklamasını içerir.
AnaBilimDaliId ve AnaBilimDali: Polikliniğin hangi ana bilim dalına bağlı olduğunu belirlemek için bir ilişki tanımlanmıştır.
Doktorlar: Poliklinik ile ilişkilendirilmiş doktorları içerir.
*/