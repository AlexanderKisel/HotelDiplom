using AutoMapper;
using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Hotel.Services.Contracts.Exceptions;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Implementations
{
    public class BookingService : IBookingService, IServiceAnchor
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBookingReadRepository bookingReadRepository;
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IPersonReadRepository personReadRepository;
        private readonly IWorkerReadRepository workerReadRepository;
        private readonly IBookingWriteRepository bookingWriteRepository;

        public BookingService(IMapper mapper, IUnitOfWork unitOfWork, IBookingReadRepository bookingReadRepository, IRoomReadRepository roomReadRepository, IPersonReadRepository personReadRepository, IWorkerReadRepository workerReadRepository, IBookingWriteRepository bookingWriteRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.bookingReadRepository = bookingReadRepository;
            this.roomReadRepository = roomReadRepository;
            this.personReadRepository = personReadRepository;
            this.workerReadRepository = workerReadRepository;
            this.bookingWriteRepository = bookingWriteRepository;
        }

        async Task<IEnumerable<BookingModel>> IBookingService.GetAllAsync(CancellationToken cancellationToken)
        {
            var bookings = await bookingReadRepository.GetAllAsync(cancellationToken);
            var roomIds = bookings.Select(x => x.RoomId).Distinct();
            var personIds = bookings.Select(x => x.PersonId).Distinct();
            var workerIds = bookings.Select(x => x.WorkerId).Distinct();

            var roomDictionary = await roomReadRepository.GetIdsAsync(roomIds, cancellationToken);
            var personDictionary = await personReadRepository.GetIdsAsync(personIds, cancellationToken);
            var workerDictionary = await workerReadRepository.GetIdsAsync(workerIds, cancellationToken);

            var listBookingModel = new List<BookingModel>();
            foreach (var booking in bookings)
            {
                if (!roomDictionary.TryGetValue(booking.RoomId, out var room))
                {
                    continue;
                }
                if (!personDictionary.TryGetValue(booking.PersonId, out var person))
                {
                    continue;
                }
                if (!workerDictionary.TryGetValue(booking.WorkerId, out var worker))
                {
                    continue;
                }
                var bookingMap = mapper.Map<BookingModel>(booking);
                bookingMap.Room = mapper.Map<RoomModel>(room);
                bookingMap.Worker = mapper.Map<WorkerModel>(worker);
                bookingMap.Person = mapper.Map<PersonModel>(person);

                listBookingModel.Add(bookingMap);
            }
            return listBookingModel;
        }

        async Task<BookingModel> IBookingService.AddAsync(BookingRequestModel booking, CancellationToken cancellationToken)
        {
            var item = new Booking
            {
                Id = Guid.NewGuid(),
                RoomId = booking.RoomId,
                PersonId = booking.PersonId,
                WorkerId = booking.WorkerId,
                DateReg = booking.DateReg,
                DateStart = booking.DateStart,
                DateEnd = booking.DateEnd,
            };

            bookingWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<BookingModel>(item);
        }

        async Task<BookingModel?> IBookingService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await bookingReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }
            var room = await roomReadRepository.GetByIdAsync(item.RoomId, cancellationToken);
            var person = await personReadRepository.GetByIdAsync(item.PersonId, cancellationToken);
            var worker = await workerReadRepository.GetByIdAsync(item.WorkerId, cancellationToken);
            var booking = mapper.Map<BookingModel>(item);
            booking.Room = room != null
                ? mapper.Map<RoomModel>(room)
                : null;
            booking.Person = person != null
                ? mapper.Map<PersonModel>(person)
                : null;
            booking.Worker = worker != null
                ? mapper.Map<WorkerModel>(room)
                : null;
            return booking;
        }

        async Task<BookingModel> IBookingService.UpdateAsync(BookingRequestModel source, CancellationToken cancellationToken)
        {
            var targetBooking = await bookingReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetBooking == null)
            {
                throw new HotelEntityNotFoundException<Booking>(source.Id);
            }
            targetBooking.DateReg = source.DateReg;
            targetBooking.DateStart = source.DateStart;
            targetBooking.DateEnd = source.DateEnd;

            var room = await roomReadRepository.GetByIdAsync(source.RoomId, cancellationToken);
            targetBooking.RoomId = room.Id;

            var person = await personReadRepository.GetByIdAsync(source.PersonId, cancellationToken);
            targetBooking.PersonId = person.Id;

            var worker = await workerReadRepository.GetByIdAsync(source.WorkerId, cancellationToken);
            targetBooking.WorkerId = worker.Id;

            bookingWriteRepository.Update(targetBooking);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<BookingModel>(targetBooking);
        }

        async Task IBookingService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetBooking = await bookingReadRepository.GetByIdAsync(id, cancellationToken);
            if(targetBooking == null)
            {
                throw new HotelEntityNotFoundException<Booking>(id);
            }
            if (targetBooking.DeletedAt.HasValue)
            {
                throw new HotelInvalidOperationException($"Бронирование с идентификатором {id} уже удалено");
            }

            bookingWriteRepository.Delete(targetBooking);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
