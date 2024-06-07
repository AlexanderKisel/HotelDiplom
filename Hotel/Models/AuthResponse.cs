using Hotel.Api.Models.Enums;

namespace Hotel.Api.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public PostsApi Post { get; set; }
        public string Id { get; set; }
    }
}
