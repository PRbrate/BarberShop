namespace BarberShop.Domain.Entities
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpireHours { get; set; }
        public string Emissor { get; set; }
        public string Audience { get; set; }
    }
}
