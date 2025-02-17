namespace Restaurant.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelefonNo { get; set; }
        public int Sayi { get; set; }
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
