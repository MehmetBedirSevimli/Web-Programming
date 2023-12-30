using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Proje.Models;
using Microsoft.AspNetCore.Identity;

namespace Proje.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet'ler buraya eklenir (Örneğin: public DbSet<Doktor> Doktorlar { get; set; })
        public DbSet<AnaBilimDali>? AnaBilimDallari { get; set; }
        public DbSet<Poliklinik>? Poliklinikler { get; set; }
        public DbSet<Doktor>? Doktorlar { get; set; }
        public DbSet<Kullanici>? Kullanicilar { get; set; }
        public DbSet<Randevu>? Randevular { get; set; }

        public DbSet<WorkingHours>? WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Diğer konfigürasyonları buraya ekle

            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
            // Diğer rolleri ekleyebilirsiniz...
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "B201210079@sakarya.edu.tr",
                    NormalizedUserName = "B201210079@SAKARYA.EDU.TR",
                    Email = "B201210079@sakarya.edu.tr",
                    NormalizedEmail = "B201210079@SAKARYA.EDU.TR",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "sau"), // Kullanıcı şifresi
                    Address = "Sample Address", // Address değeri ekleyin
                    FullName = "Admin User", // FullName ve Birthdate gibi özelliklere uygun değerleri ekleyin
                    Birthdate = DateTime.Now.AddYears(-25) // Örnek bir doğum tarihi
                }
            // Diğer kullanıcıları ekleyebilirsiniz...
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1", // Admin rolünün ID'si
                    UserId = "1" // Yukarıdaki Admin kullanıcısının ID'si
                }
            // Diğer rol-atama ilişkilerini ekleyebilirsiniz...
            );
        }



    }
}
