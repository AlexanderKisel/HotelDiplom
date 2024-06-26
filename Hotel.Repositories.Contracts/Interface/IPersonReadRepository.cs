﻿using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий чтения <see cref="Person"/>
    /// </summary>
    public interface IPersonReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Person"/>
        /// </summary>
        Task<List<Person>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Person"/> по идентификатору
        /// </summary>
        Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Person"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Person>> GetIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Person"/> в колекции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Person"/> в колекции
        /// </summary>
        Task<bool> AnyByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Person"/> по логину и паролю
        /// </summary>
        Task<Person?> GetByPersonAsync(string login, string password,  CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Person"/> в колекции
        /// </summary>
        Task<bool> AnyByPhoneAsync(string phone, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Person"/> в колекции
        /// </summary>
        Task<bool> AnyByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Проверить есть ли <see cref="Person"/> в колекции
        /// </summary>
        Task<bool> AnyByLoginAsync(string login, CancellationToken cancellationToken);

        /// <summary>
        /// Хеширование пароля
        /// </summary>
        string GetHashSha256(string password);
    }
}
