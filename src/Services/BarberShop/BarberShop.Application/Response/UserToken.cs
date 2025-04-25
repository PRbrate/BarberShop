namespace BarberShop.Application.Response
{
    public class UserToken
    {
        public string AccessToken { get; set; }
        public UserDTO User { get; set; }
    }
}
