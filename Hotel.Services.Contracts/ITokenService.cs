using Hotel.Context.Contracts.Enums;
using Hotel.Services.Contracts.Models;

namespace Hotel.Services.Contracts
{
    public interface ITokenService
    {
        Task<AuthModel> AutorizationPerson(string login, string password, CancellationToken cancellationToken);
    }
}