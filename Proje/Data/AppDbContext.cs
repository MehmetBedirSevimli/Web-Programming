using Microsoft.EntityFrameworkCore;
using Proje.Models;

namespace Proje.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet'ler buraya eklenir (Örneğin: public DbSet<Doktor> Doktorlar { get; set; })
        public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

        public DbSet<WorkingHours> WorkingHours { get; set; }
    }
}
