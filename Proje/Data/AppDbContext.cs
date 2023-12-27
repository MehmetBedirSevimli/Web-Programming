using Microsoft.EntityFrameworkCore;

namespace Proje.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet'ler buraya eklenir (Örneğin: public DbSet<Doktor> Doktorlar { get; set; })
    }
}
