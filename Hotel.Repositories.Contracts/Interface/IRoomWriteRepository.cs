using Hotel.Context.Contracts.Models;

namespace Hotel.Repositories.Contracts.Interface
{
    /// <summary>
    /// Репозиторий записи <see cref="Room"/>
    /// </summary>
    public interface IRoomWriteRepository : IRepositoryWrite<Room>
    {
    }
}
