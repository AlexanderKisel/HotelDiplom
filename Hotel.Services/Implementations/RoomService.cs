using AutoMapper;
using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Contracts.Enums;
using Hotel.Context.Contracts.Models;
using Hotel.Repositories.Contracts.Interface;
using Hotel.Services.Contracts.Exceptions;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.ModelsRequest;

namespace Hotel.Services.Implementations
{
    public class RoomService : IRoomService, IServiceAnchor
    {
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoomWriteRepository roomWriteRepository;

        public RoomService(IRoomReadRepository roomReadRepository, IMapper mapper, IUnitOfWork unitOfWork, IRoomWriteRepository roomWriteRepository)
        {
            this.roomReadRepository = roomReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.roomWriteRepository = roomWriteRepository;
        }

        async Task<IEnumerable<RoomModel>> IRoomService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await roomReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<RoomModel>>(result);
        }

        async Task<RoomModel?> IRoomService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }
            return mapper.Map<RoomModel>(item);
        }

        async Task<RoomModel> IRoomService.AddAsync(RoomRequestModel room, CancellationToken cancellationToken)
        {
            var item = new Room
            {
                Id = Guid.NewGuid(),
                Number = room.Number,
                NumberOfSeats = room.NumberOfSeats,
                NumberOfRooms = room.NumberOfRooms,
                Price = room.Price,
                Description = room.Description,
                TypeRooms = (TypeRooms)room.TypeRooms
            };

            roomWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<RoomModel>(item);
        }

        async Task<RoomModel> IRoomService.UpdateAsync(RoomRequestModel source, CancellationToken cancellationToken)
        {
            var targetRoom = await roomReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetRoom == null)
            {
                throw new HotelEntityNotFoundException<Person>(source.Id);
            }
            targetRoom.Number = source.Number;
            targetRoom.NumberOfSeats = source.NumberOfSeats;
            targetRoom.NumberOfRooms = source.NumberOfRooms;
            targetRoom.Price = source.Price;
            targetRoom.Description = source.Description;
            targetRoom.TypeRooms = (TypeRooms)source.TypeRooms;

            roomWriteRepository.Update(targetRoom);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<RoomModel>(targetRoom);
        }

        async Task IRoomService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetRoom = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetRoom == null)
            {
                throw new HotelEntityNotFoundException<Room>(id);
            }
            if (targetRoom.DeletedAt.HasValue)
            {
                throw new HotelInvalidOperationException($"Персона с идентификатором {id} уже удален");
            }

            roomWriteRepository.Delete(targetRoom);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
