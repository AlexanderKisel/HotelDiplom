using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Repositories.Implimentations
{
    public class WorkerWriteRepository : BaseWriteRepository<Worker>,
        IWorkerWriteRepository,
        IRepositoryAnchor
    {
        public WorkerWriteRepository(IDbWriteContext writeContext)
        : base(writeContext) { }
    }
}
