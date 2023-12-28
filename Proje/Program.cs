using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // veya ba�ka bir veritaban� sa�lay�c�s� kullan�l�yorsa ona g�re belirtin.
});

/*
 *  builder.Services.AddIdentity<ApplicationUser, IdentityRole>() ile 
 *  Identity servislerini ekledik. Ayr�ca, builder.Services.AddEntityFrameworkStores<AppDbContext>() ile
 *  kullan�c� ve rol verilerini veritaban�nda saklamak i�in Entity Framework kullan�laca��n� belirttik.

Not: AddIdentity metodunun ilk parametresi kullan�c� s�n�f�n�z (ApplicationUser), 
ikinci parametresi ise rol s�n�f�n�z (IdentityRole) olmal�d�r. E�er �zel bir rol s�n�f�n�z yoksa, 
IdentityRole kullanabilirsiniz.
*/
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity'nin Authentication middleware'ini ekledim.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
