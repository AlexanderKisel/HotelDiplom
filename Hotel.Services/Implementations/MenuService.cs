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
    public class MenuService : IMenuService, IServiceAnchor
    {
        private readonly IMenuReadRepository menuReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMenuWriteRepository menuWriteRepository;

        public MenuService(IMenuReadRepository menuReadRepository, IMapper mapper, IUnitOfWork unitOfWork, IMenuWriteRepository menuWriteRepository)
        {
            this.menuReadRepository = menuReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.menuWriteRepository = menuWriteRepository;
        }

        async Task<IEnumerable<MenuModel>> IMenuService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await menuReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<MenuModel>>(result);
        }

        async Task<MenuModel?> IMenuService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await menuReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }
            return mapper.Map<MenuModel>(item);    
        }

        async Task<MenuModel> IMenuService.AddAsync(MenuRequestModel booking, CancellationToken cancellationToken)
        {
            var item = new Menu
            {
                Id = Guid.NewGuid(),
                Name = booking.Name,
                Price = booking.Price,
                Description = booking.Description,
                TypeEat = (TypeEat)booking.TypeEat,
            };

            menuWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<MenuModel>(item);
        }

        async Task<MenuModel> IMenuService.UpdateAsync(MenuRequestModel source, CancellationToken cancellationToken)
        {
            var targetMenu = await menuReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetMenu == null)
            {
                throw new HotelEntityNotFoundException<Menu>(source.Id);
            }
            targetMenu.Name = source.Name;
            targetMenu.Price = source.Price;
            targetMenu.Description = source.Description;
            targetMenu.TypeEat = (TypeEat)source.TypeEat;

            menuWriteRepository.Update(targetMenu);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<MenuModel>(targetMenu);
        }

        async Task IMenuService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetMenu = await menuReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetMenu == null)
            {
                throw new HotelEntityNotFoundException<Menu>(id);
            }
            if (targetMenu.DeletedAt.HasValue)
            {
                throw new HotelInvalidOperationException($"Блюдо с идентификатором {id} уже удален");
            }

            menuWriteRepository.Delete(targetMenu);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
