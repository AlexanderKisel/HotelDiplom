using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Contracts.Interface
{
    public interface IMenuService
    {
        /// <summary>
        /// Получить список всех <see cref="MenuModel"/>
        /// </summary>
        Task<IEnumerable<MenuModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="MenuModel"/>
        /// </summary>
        Task<MenuModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление блюда меню
        /// </summary>
        Task<MenuModel> AddAsync(MenuRequestModel booking, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет существующее блюдо в меню
        /// </summary>
        Task<MenuModel> UpdateAsync(MenuRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее блюдо
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
