using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using NToastNotify;
using Restaurant.Models.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Cafe.Email;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Veritabanı bağlantısını yapılandır
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<VeriTabaniContext>(options =>
                options.UseSqlServer(connectionString));

            // Identity servislerini ekle (Default UI olmadan)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<VeriTabaniContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddAuthorization();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Kimlik doğrulama ve yetkilendirme
            app.UseAuthentication();
            app.UseAuthorization();

            // Statik dosyalar için eşleşme
            app.MapStaticAssets();

            // Rotaları belirle
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Razor Pages ekleyelim
            app.MapRazorPages().WithStaticAssets();

            // NToastNotify Kullanımı
            app.UseNToastNotify();

            app.Run();
        }
    }
}
