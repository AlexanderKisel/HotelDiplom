using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Implimentations
{
    public class RoomReadRepository : IRoomReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public  RoomReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<List<Room>> IRoomReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Room>()
            .NotDeletedAt()
            .OrderBy(x => x.Number)
            .ThenBy(x => x.Price)
            .ToListAsync(cancellationToken);

        Task<Room?> IRoomReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Room>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Room>> IRoomReadRepository.GetIdsAsync(IEnumerable<System.Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Room>()
            .NotDeletedAt()
            .ByIds(ids)
            .OrderBy(x => x.Number)
            .ThenBy(x => x.Price)
            .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IRoomReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Room>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);

        Task<bool> IRoomReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Room>().NotDeletedAt().AnyAsync(x => x.Id == id, cancellationToken);
    }
}
