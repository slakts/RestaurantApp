using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string  KullaniciAdi{ get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string TelefonNo { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
