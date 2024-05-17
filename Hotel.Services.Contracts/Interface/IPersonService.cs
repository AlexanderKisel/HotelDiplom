using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Contracts.Interface
{
    public interface IPersonService
    {
        /// <summary>
        /// Получить список всех <see cref="PersonModel"/>
        /// </summary>
        Task<IEnumerable<PersonModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="PersonModel"/>
        /// </summary>
        Task<PersonModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление персон(клиентов)
        /// </summary>
        Task<PersonModel> AddAsync(PersonRequestModel booking, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет существующую персону
        /// </summary>
        Task<PersonModel> UpdateAsync(PersonRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующую персону
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
