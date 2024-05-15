using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Booking"/>
    /// </summary>
    public interface IBookingReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Booking"/>
        /// </summary>
        Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Booking"/> по илентификатору
        /// </summary>
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Booking"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Booking>> GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Booking"/> в колекции
        /// </summary>
        Task<bool> IsNotNullAsync (Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Booking"/> в колекции
        /// </summary>
        Task<bool> AnyByIdAsync (Guid id, CancellationToken cancellationToken);
    }
}
