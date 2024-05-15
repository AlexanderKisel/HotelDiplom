using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories.Implimentations
{
    public class RoomWriteRepository : BaseWriteRepository<Room>,
        IRoomWriteRepository,
        IRepositoryAnchor
    {
        public RoomWriteRepository(IDbWriteContext writeContext)
        : base(writeContext){ }
    }
}
