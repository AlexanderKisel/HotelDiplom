namespace Hotel.Services.Contracts
{
    public interface ITokenService
    {
        Task<string> AutorizationPerson(string login, string password, CancellationToken cancellationToken);
    }
}
