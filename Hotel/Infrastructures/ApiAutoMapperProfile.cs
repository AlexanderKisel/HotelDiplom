using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Hotel.Api.Models;
using Hotel.Api.Models.Enums;
using Hotel.ModelsRequest.Booking;
using Hotel.ModelsRequest.Menu;
using Hotel.ModelsRequest.Person;
using Hotel.ModelsRequest.Room;
using Hotel.ModelsRequest.Worker;
using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.Models.Enums;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.OpenApi.Extensions;

namespace Hotel.Infrastructures
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile() 
        {
            CreateMap<PostModel, PostsApi>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<TypeEatModel, TypeEatApi>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<TypeRoomModel, TypeRoomsApi>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<RoomModel, RoomResponse>(MemberList.Destination)
                .ForMember(x => x.TypeRoom, y => y.MapFrom(z => z.TypeRooms.GetDisplayName()));
            CreateMap<CreateRoomRequest, RoomRequestModel>(MemberList.Destination);
            CreateMap<EditRoomRequest, RoomRequestModel>(MemberList.Destination);

            CreateMap<WorkerModel, WorkerResponse>(MemberList.Destination)
                .ForMember(x => x.Post, y => y.MapFrom(z => z.Posts.GetDisplayName()));
            CreateMap<CreateWorkerRequest, WorkerRequestModel>(MemberList.Destination);
            CreateMap<EditWorkerRequest, WorkerRequestModel>(MemberList.Destination);

            CreateMap<MenuModel, MenuResponse>(MemberList.Destination)
                .ForMember(x => x.TypeEat, y => y.MapFrom(z => z.TypeEat.GetDisplayName()));
            CreateMap<CreateMenuRequest, MenuRequestModel>(MemberList.Destination);
            CreateMap<EditMenuRequest, MenuRequestModel>(MemberList.Destination);

            CreateMap<PersonModel, PersonResponse>(MemberList.Destination);
            CreateMap<CreatePersonRequest, PersonRequestModel>(MemberList.Destination);
            CreateMap<EditPersonRequest, PersonRequestModel>(MemberList.Destination);

            CreateMap<BookingModel, BookingResponse>(MemberList.Destination)
                .ForMember(x => x.NumberRoom, y => y.MapFrom(z => $"{z.Room.Number}"))
                .ForMember(x => x.FIOPerson, y => y.MapFrom(z => $"{z.Person.FIO}"))
                .ForMember(x => x.FIOWorker, y => y.MapFrom(z => $"{z.Worker.FIO}"));
            CreateMap<CreateBookingRequest, BookingRequestModel>(MemberList.Destination);
            CreateMap<EditBookingRequest, BookingRequestModel>(MemberList.Destination);
        }
    }
}
