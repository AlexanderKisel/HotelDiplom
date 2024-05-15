using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Repositories.Implimentations
{
    public class BookingWriteRepository : BaseWriteRepository<Booking>,
        IBookingWriteRepository,
        IRepositoryAnchor
    {
        public BookingWriteRepository(IDbWriteContext writeContext)
            : base(writeContext) { }
    }
}
