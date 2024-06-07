using Hotel.Context.Contracts.Enums;
using Hotel.Repositories.Contracts.Interface;
using Hotel.Services.Contracts;
using Hotel.Services.Contracts.Exceptions;
using Hotel.Services.Contracts.Models;
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

        async Task<AuthModel> ITokenService.AutorizationPerson(string login, string password, CancellationToken cancellationToken)
        {
            var person = await personReadRepository.GetByPersonAsync(login, password, cancellationToken);
            var worker = await workerReadRepository.GetByWorkerAsync(login, password, cancellationToken);
            var claims = new List<Claim>();
            AuthModel authModel;

            if (person == null && worker == null)
            {
                throw new HotelInvalidOperationException("USER_NOT_FOUND");
            };

            if (person != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, person.Login));
                claims.Add(new Claim(ClaimTypes.Role, Posts.None.ToString()));
                claims.Add(new Claim("Id", person.Id.ToString()));
                authModel = new AuthModel(person.Id.ToString());
                authModel.Post = Posts.None;
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Name, worker.Login));
                claims.Add(new Claim(ClaimTypes.Role, worker.Posts.ToString()));
                claims.Add(new Claim("Id", worker.Id.ToString()));
                authModel = new AuthModel(worker.Id.ToString());
                authModel.Post = worker.Posts;
            }
            var accessToken = GenerateAccessToken(claims);
            authModel.Token = accessToken;
            return authModel;
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
