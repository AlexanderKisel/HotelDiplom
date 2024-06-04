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
                .ForMember(x => x.TypeRoom, y => y.MapFrom(z => z.TypeRoom.ToString()));
            CreateMap<CreateRoomRequest, RoomRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditRoomRequest, RoomRequestModel>(MemberList.Destination);

            CreateMap<WorkerModel, WorkerResponse>(MemberList.Destination)
                .ForMember(x => x.Post, y => y.MapFrom(z => z.Posts.ToString()));
            CreateMap<CreateWorkerRequest, WorkerRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditWorkerRequest, WorkerRequestModel>(MemberList.Destination);

            CreateMap<MenuModel, MenuResponse>(MemberList.Destination)
                .ForMember(x => x.TypeEat, y => y.MapFrom(z => z.TypeEat.ToString()));
            CreateMap<CreateMenuRequest, MenuRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditMenuRequest, MenuRequestModel>(MemberList.Destination);

            CreateMap<PersonModel, PersonResponse>(MemberList.Destination);
            CreateMap<CreatePersonRequest, PersonRequestModel>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPersonRequest, PersonRequestModel>(MemberList.Destination);

            CreateMap<BookingModel, BookingResponse>(MemberList.Destination)
                .ForMember(x => x.NumberRoom, y => y.MapFrom(z => $"{z.Room.Number}"))
                .ForMember(x => x.PriceRoom, y => y.MapFrom(z => $"{z.Room.Price}"))
                .ForMember(x => x.FIOPerson, y => y.MapFrom(z => $"{z.Person.FIO}"))
                .ForMember(x => x.FIOWorker, y => y.MapFrom(z => $"{z.Worker.FIO}"));
            CreateMap<CreateBookingRequest, BookingRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditBookingRequest, BookingRequestModel>(MemberList.Destination);

            CreateMap<AuthModel, AuthResponse>(MemberList.Destination);
        }
    }
}
