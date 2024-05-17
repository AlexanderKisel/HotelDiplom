﻿using Hotel.Context.Contracts.Models;

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
        Task<List<Worker>> GetAllAsync(CancellationToken cancellationToken);

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
    }
}