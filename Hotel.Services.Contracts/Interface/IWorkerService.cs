using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Contracts.Interface
{
    public interface IWorkerService
    {
        /// <summary>
        /// Получить список всех <see cref="WorkerModel"/>
        /// </summary>
        Task<IEnumerable<WorkerModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="WorkerModel"/>
        /// </summary>
        Task<WorkerModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление работника
        /// </summary>
        Task<WorkerModel> AddAsync(WorkerRequestModel booking, CancellationToken cancellationToken);

        /// <summary>
        /// Изменяет существующего работника
        /// </summary>
        Task<WorkerModel> UpdateAsync(WorkerRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего работника
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
