namespace BarberShop.Application
{
    public class HaircutDTQ
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }
        public bool? Status { get; set; }
    }
}
