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
    public class PersonService : IPersonService, IServiceAnchor
    {
        private readonly IPersonReadRepository personReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonWriteRepository personWriteRepository;

        public PersonService(IPersonReadRepository personReadRepository, IMapper mapper, IUnitOfWork unitOfWork, IPersonWriteRepository personWriteRepository)
        {
            this.personReadRepository = personReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.personWriteRepository = personWriteRepository;
        }

        async Task<IEnumerable<PersonModel>> IPersonService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await personReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<PersonModel>>(result);
        }

        async Task<PersonModel?> IPersonService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await personReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }
            return mapper.Map<PersonModel>(item);
        }

        async Task<PersonModel> IPersonService.AddAsync(PersonRequestModel person, CancellationToken cancellationToken)
        {
            var item = new Person
            {
                Id = Guid.NewGuid(),
                FIO = person.FIO,
                Email = person.Email,
                Phone = person.Phone,
                Login = person.Login,
                Password = personReadRepository.GetHashSha256(person.Password),
                Birthday = person.Birthday,
            };

            personWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PersonModel>(item);
        }

        async Task<PersonModel> IPersonService.UpdateAsync(PersonRequestModel source, CancellationToken cancellationToken)
        {
            var targetPerson = await personReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPerson == null)
            {
                throw new HotelEntityNotFoundException<Person>(source.Id);
            }
            targetPerson.FIO = source.FIO;
            targetPerson.Email = source.Email;
            targetPerson.Phone = source.Phone;
            targetPerson.Login = source.Login;
            targetPerson.Password = source.Password;
            targetPerson.Birthday = source.Birthday;

            personWriteRepository.Update(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PersonModel>(targetPerson);
        }

        async Task IPersonService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetPerson = await personReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetPerson == null)
            {
                throw new HotelEntityNotFoundException<Person>(id);
            }
            if (targetPerson.DeletedAt.HasValue)
            {
                throw new HotelInvalidOperationException($"Персона с идентификатором {id} уже удален");
            }

            personWriteRepository.Delete(targetPerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
