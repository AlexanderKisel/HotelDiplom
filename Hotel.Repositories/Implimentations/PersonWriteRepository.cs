using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Repositories.Implimentations
{
    public class PersonWriteRepository : BaseWriteRepository<Person>,
        IPersonWriteRepository,
        IRepositoryAnchor
    {
        public PersonWriteRepository(IDbWriteContext writeContext) 
        : base(writeContext){ }
    }
}
