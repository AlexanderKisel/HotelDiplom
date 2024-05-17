using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Contracts.Interface
{
    public interface IRoomService
    {
        /// <summary>
        /// Получить список всех <see cref="RoomModel"/>
        /// </summary>
        Task<IEnumerable<RoomModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="RoomModel"/>
        /// </summary>
        Task<RoomModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление комнаты(номера)
        /// </summary>
        Task<RoomModel> AddAsync(RoomRequestModel booking, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет существующую комнату
        /// </summary>
        Task<RoomModel> UpdateAsync(RoomRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующую комнату
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
