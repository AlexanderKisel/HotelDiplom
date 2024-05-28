using Hotel.Repositories.Contracts.Interface;
using Hotel.Services.Contracts;
using Hotel.Services.Contracts.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Hotel.Services
{
    public class AuthorizationService : ITokenService, IServiceAnchor
    {
        private readonly IPersonReadRepository personReadRepository;
        private readonly IWorkerReadRepository workerReadRepository;

        public AuthorizationService(IPersonReadRepository userReadRepository, IWorkerReadRepository workerReadRepository)
        {
            this.personReadRepository = userReadRepository;
            this.workerReadRepository = workerReadRepository;
        }

        async Task<string> ITokenService.AutorizationPerson(string login, string password, CancellationToken cancellationToken)
        {
            var person = await personReadRepository.GetByPersonAsync(login, password, cancellationToken);
            var worker = await workerReadRepository.GetByWorkerAsync(login, password, cancellationToken);
            var claims = new List<Claim>();

            if (person == null && worker == null)
            {
                throw new HotelInvalidOperationException("USER_NOT_FOUND");
            };

            if(person != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, person.Login));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Name, worker.Login));
            }
            var accessToken = GenerateAccessToken(claims);
            return accessToken;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = Auth.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                 issuer: Auth.ISSUER,
            audience: Auth.AUDIENCE,
                 claims: claims,
                 expires: DateTime.UtcNow.AddMinutes(Auth.LIFETIME),
                 signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
