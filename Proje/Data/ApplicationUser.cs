using Microsoft.AspNetCore.Identity;

namespace Proje.Data
{
    public class ApplicationUser : IdentityUser
    {
        //IdentityUser sınıfından gelen özelliklere ek olarak, özel alanları buraya ekleyebilirsiniz.
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        // Diğer özel alanlar...

        // İhtiyaca bağlı olarak ek bilgiler ekleyebilirsiniz.
        //public ICollection<SomeEntity> SomeEntities { get; set; }
    }
}
//deneme