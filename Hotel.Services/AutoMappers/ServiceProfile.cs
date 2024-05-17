using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Hotel.Context.Contracts.Enums;
using Hotel.Context.Contracts.Models;
using Hotel.Services.Contracts.Models;
using Hotel.Services.Contracts.Models.Enums;

namespace Hotel.Services.AutoMappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile() 
        {
            CreateMap<Posts, PostModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<TypeEat, TypeEatModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<TypeRooms, TypeRoomModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Booking, BookingModel>(MemberList.Destination);
            CreateMap<Menu, MenuModel>(MemberList.Destination);
            CreateMap<Person, PersonModel>(MemberList.Destination);
            CreateMap<Room, RoomModel>(MemberList.Destination);
            CreateMap<Worker, WorkerModel>(MemberList.Destination);
        }
    }
}
