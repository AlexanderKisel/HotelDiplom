using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Hotel.Repositories.Implimentations
{
    public class WorkerReadRepository : IWorkerReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public WorkerReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<List<Worker>> IWorkerReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Worker>()
            .NotDeletedAt()
            .OrderBy(x => x.FIO)
            .ThenBy(x => x.Login)
            .ToListAsync(cancellationToken);

        Task<Worker?> IWorkerReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Worker>()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Worker>> IWorkerReadRepository.GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Worker>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.FIO)
                .ThenBy(x => x.Login)
                .ToDictionaryAsync(key => key.Id, cancellationToken);
        Task<bool> IWorkerReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Worker>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);

        Task<bool> IWorkerReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
        => reader.Read<Worker>().NotDeletedAt().AnyAsync(x => x.Id == id, cancellationToken);

        Task<Worker?> IWorkerReadRepository.GetByWorkerAsync(string login, string password, CancellationToken cancellationToken)
            => reader.Read<Worker>().NotDeletedAt().FirstOrDefaultAsync(x => x.Login == login && x.Password == GetHashSha256(password), cancellationToken);

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

        Task<bool> IWorkerReadRepository.AnyByPhoneAsync(string phone, CancellationToken cancellationToken)
            => reader.Read<Worker>().NotDeletedAt().AnyAsync(x => x.Phone == phone, cancellationToken);

        Task<bool> IWorkerReadRepository.AnyByEmailAsync(string email, CancellationToken cancellationToken)
            => reader.Read<Worker>().NotDeletedAt().AnyAsync(x => x.Email == email, cancellationToken);
        Task<bool> IWorkerReadRepository.AnyByLoginAsync(string login, CancellationToken cancellationToken)
            => reader.Read<Worker>().NotDeletedAt().AnyAsync(x => x.Login == login, cancellationToken);
    }
}
