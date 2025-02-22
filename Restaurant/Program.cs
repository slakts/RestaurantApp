using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using NToastNotify;

namespace Restaurant;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Veritabaný baðlantýsýný yapýlandýr
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<VeriTabaniContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // Identity servislerini ekle (Default UI olmadan)
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<VeriTabaniContext>()
        .AddDefaultTokenProviders(); // Þifre sýfýrlama vb. için token saðlayýcýlarý ekler.

        // Özel giriþ sayfasýný ayarla
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login"; // Özel login sayfanýn yolu
            options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eriþim sayfasý
            options.LogoutPath = "/Account/Logout"; // Çýkýþ sayfasý
        });

        // Razor Pages ve MVC servisini ekleyelim (HATA BURADAN KAYNAKLANIYORDU)
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages(); // Bunu ekledik!

        // Yetkilendirme servislerini ekle
        builder.Services.AddAuthorization();

        // NToastNotify servislerini ekle
        builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
        {
            ProgressBar = true,
            PositionClass = ToastPositions.TopRight
        });

        var app = builder.Build();

        // Hata yönetimi
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Response Cache engelleme (sayfa geri gidildiðinde tekrar giriþ gerektirmesi için)
        app.Use(async (context, next) =>
        {
            await next();

            if (!context.Response.HasStarted)
            {
                context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                context.Response.Headers["Pragma"] = "no-cache";
                context.Response.Headers["Expires"] = "0";
            }
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Kimlik doðrulama ve yetkilendirme
        app.UseAuthentication();
        app.UseAuthorization();

        // Statik dosyalar için eþleþme
        app.MapStaticAssets();

        // Rotalarý belirle
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        // Razor Pages ekleyelim (Burasý hataya sebep oluyordu)
        app.MapRazorPages().WithStaticAssets();

        // NToastNotify Kullanýmý
        app.UseNToastNotify();

        app.Run();
    }
}