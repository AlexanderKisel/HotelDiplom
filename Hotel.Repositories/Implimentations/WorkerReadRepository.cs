using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

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
    }
}
