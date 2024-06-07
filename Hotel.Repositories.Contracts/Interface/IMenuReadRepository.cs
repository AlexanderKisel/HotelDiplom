using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Menu"/>
    /// </summary>
    public interface IMenuReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Menu"/>
        /// </summary>
        Task<IReadOnlyCollection<Menu>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Menu"/> по илентификатору
        /// </summary>
        Task<Menu?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Menu"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Menu>> GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Menu"/> в колекции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Menu"/> в колекции
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
