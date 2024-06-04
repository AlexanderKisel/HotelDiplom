using Hotel.Context.Contracts.Enums;

namespace Hotel.Services.Contracts.Models
{
    public class AuthModel
    {
        public string Token { get; set; }
        public Posts Post { get; set; }
    }
}
