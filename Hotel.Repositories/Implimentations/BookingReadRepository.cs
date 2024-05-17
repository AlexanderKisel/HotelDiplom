using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common.Entity.Repositories;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Implimentations
{
    public class BookingReadRepository : IBookingReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public BookingReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<List<Booking>> IBookingReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Booking>()
            .NotDeletedAt()
            .OrderBy(x => x.Id)
            .ThenBy(x => x.WorkerId)
            .ThenBy(x => x.PersonId)
            .ThenBy(x => x.RoomId)
            .ToListAsync(cancellationToken);

        Task<Booking?> IBookingReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Booking>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Booking>> IBookingReadRepository.GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Booking>()
            .NotDeletedAt()
            .ByIds(ids)
            .OrderBy(x => x.Id)
            .ThenBy(x => x.WorkerId)
            .ThenBy(x => x.PersonId)
            .ThenBy(x => x.RoomId)
            .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IBookingReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Booking>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);

        Task<bool> IBookingReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Booking>().NotDeletedAt().AnyAsync(x => x.Id == id, cancellationToken);
    }
}
