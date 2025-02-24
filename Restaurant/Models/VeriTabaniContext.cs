using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Entities;

namespace Restaurant.Models
{
    public class VeriTabaniContext : IdentityDbContext<ApplicationUser>
    {
        public VeriTabaniContext(DbContextOptions<VeriTabaniContext> options) : base(options)
        {
        }

        // DbSet'lerinizi buraya ekleyin

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Iletisim> Iletisimler { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
