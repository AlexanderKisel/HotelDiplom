using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий записи <see cref="Booking"/>
    /// </summary>
    public interface IBookingWriteRepository : IRepositoryWrite<Booking>
    {
    }
}
