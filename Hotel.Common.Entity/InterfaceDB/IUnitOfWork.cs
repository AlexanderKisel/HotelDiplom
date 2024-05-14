namespace Hotel.Common.Entity.InterfaceDB
{
    /// <summary>
    /// Определяет интерфейс для Unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Асинхронно сохраняет все изменения в бд
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
