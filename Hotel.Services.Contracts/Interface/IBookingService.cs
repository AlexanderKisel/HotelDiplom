using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Contracts.Interface
{
    public interface IBookingService
    {
        /// <summary>
        /// Получить отфильтрованный список бронирований <see cref="BookingModel"/>
        /// </summary>
        Task<IEnumerable<BookingModel>> GetFilteredBookingsAsync(string userId, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список всех <see cref="BookingModel"/>
        /// </summary>
        Task<IEnumerable<BookingModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="BookingModel"/>
        /// </summary>
        Task<BookingModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление бронирования
        /// </summary>
        Task<BookingModel> AddAsync(BookingRequestModel booking, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет существующее бронировании
        /// </summary>
        Task<BookingModel> UpdateAsync(BookingRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее бронирование
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
