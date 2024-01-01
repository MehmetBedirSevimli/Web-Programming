namespace WebProgramlama.Models
{
    public class AnaBilimDali
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Aciklama { get; set; }

        // Diğer özellikler eklenebilir.

        // İlişki
        public ICollection<Poliklinik> Poliklinikler { get; set; }
    }

}

/*Bu örnekte AnaBilimDali sınıfına eklediğim özellikler şunlar:

Id: Ana bilim dalının benzersiz kimliğini temsil eder.
Adi: Ana bilim dalının adını temsil eder.
Aciklama: Ana bilim dalının kısa bir açıklamasını içerir.
Poliklinikler: Bir ana bilim dalının birden çok polikliniği olabilir, bu nedenle Poliklinik sınıfı ile ilişkilidir.
*/