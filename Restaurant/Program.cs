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

        // Servisleri kapsayýcýya ekleyin.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<VeriTabaniContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // Kimlik servislerini ekleyin.
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<VeriTabaniContext>();
        builder.Services.AddControllersWithViews();

        // Yetkilendirme servislerini ekleyin.
        builder.Services.AddAuthorization();

        // NToastNotify servislerini ekleyin.
        builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
        {
            ProgressBar = true,
            PositionClass = ToastPositions.TopRight
        });

        var app = builder.Build();

        // HTTP istek hattýný yapýlandýrýn.
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
        app.UseAuthentication(); // Bu satýr eklendi
        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "Areas",
            pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapRazorPages()
            .WithStaticAssets();

        app.UseNToastNotify();

        app.Run();
    }
}
