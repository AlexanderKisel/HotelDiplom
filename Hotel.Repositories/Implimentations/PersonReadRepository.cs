using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

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
    }
}
