using System.Text.Json.Serialization;

namespace BarberShop.Core
{
    public class Response<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Errors { get; set; }
    }
}
