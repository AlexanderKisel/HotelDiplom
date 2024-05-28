using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Hotel.Repositories.Implimentations
{
    public class PersonReadRepository : IPersonReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public PersonReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<List<Person>> IPersonReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Person>()
            .NotDeletedAt()
            .OrderBy(x => x.FIO)
            .ThenBy(x => x.Login)
            .ToListAsync(cancellationToken);

        Task<Person?> IPersonReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Person>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Person>> IPersonReadRepository.GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Person>()
            .NotDeletedAt()
            .ByIds(ids)
            .OrderBy(x => x.FIO)
            .ThenBy(x => x.Login)
            .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IPersonReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Person>().NotDeletedAt().AnyAsync(x => x.Id == id, cancellationToken);

        Task<bool> IPersonReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Person>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);

        Task<Person?> IPersonReadRepository.GetByPersonAsync(string login, string password, CancellationToken cancellationToken)
            => reader.Read<Person>().NotDeletedAt().FirstOrDefaultAsync(x => x.Login ==  login && x.Password == GetHashSha256(password), cancellationToken);

        public string GetHashSha256(string password)
        {
            using (var hashString = SHA256.Create())
            {
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] hash = hashString.ComputeHash(bytes);
                string hashstring = "";
                foreach (byte x in hash)
                {
                    hashstring += String.Format("{0:x2}", x);
                }
                return hashstring;
            }
        }
    }
}
