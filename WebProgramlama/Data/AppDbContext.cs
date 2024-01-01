using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProgramlama.Models;

namespace WebProgramlama.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<CalismaSaatleri> CalismaSaatleri { get; set; }
    }
}