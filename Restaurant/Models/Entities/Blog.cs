namespace Restaurant.Models.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public bool Onay { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
    }
}
