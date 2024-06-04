using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Worker"/>
    /// </summary>
    public interface IWorkerReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Worker"/>
        /// </summary>
        Task<IReadOnlyCollection<Worker>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Worker"/> по илентификатору
        /// </summary>
        Task<Worker?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Worker"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Worker>> GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Worker"/> в колекции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Worker"/> в колекции
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Worker"/> по логину и паролю
        /// </summary>
        Task<Worker?> GetByWorkerAsync(string login, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Worker"/> в колекции
        /// </summary>
        Task<bool> AnyByPhoneAsync(string phone, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Worker"/> в колекции
        /// </summary>
        Task<bool> AnyByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Worker"/> в колекции
        /// </summary>
        Task<bool> AnyByLoginAsync(string login, CancellationToken cancellationToken);

        /// <summary>
        /// Хеширование пароля
        /// </summary>
        string GetHashSha256(string password);
    }
}
