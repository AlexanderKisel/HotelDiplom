using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Implimentations
{
    public class MenuReadRepository : IMenuReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public MenuReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }
        Task<bool> IMenuReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Menu>().NotDeletedAt().AnyAsync(x => x.Id == id, cancellationToken);
        Task<IReadOnlyCollection<Menu>> IMenuReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Menu>()
            .NotDeletedAt()
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Price)
            .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Menu?> IMenuReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Menu>()
            .ById(id)
            .NotDeletedAt()
            .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Menu>> IMenuReadRepository.GetIdsAsync(IEnumerable <Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Menu>()
            .NotDeletedAt()
            .ByIds(ids)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Price)
            .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IMenuReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Menu>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
    }
}
