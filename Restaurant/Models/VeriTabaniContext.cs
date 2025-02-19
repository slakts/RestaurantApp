using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Entities;

namespace Restaurant.Models
{
    public class VeriTabaniContext : DbContext
    {
        public VeriTabaniContext(DbContextOptions<VeriTabaniContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Iletisim> Iletisimler { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Özel model yapılandırmalarını buraya ekleyebilirsiniz.
        }
    }
}
