using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Repositories.Implimentations
{
    /// <summary>
    /// <inheritdoc cref="IMenuWriteRepository"/>
    /// </summary>
    public class MenuWriteRepository : BaseWriteRepository<Menu>,
        IMenuWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MenuWriteRepository"/>
        /// </summary>
        public MenuWriteRepository(IDbWriteContext writeContext) 
            : base(writeContext) { }
    }
}
