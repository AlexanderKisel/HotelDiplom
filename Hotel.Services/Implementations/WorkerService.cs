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
    public class WorkerService : IWorkerService, IServiceAnchor
    {
        private readonly IWorkerReadRepository workerReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWorkerWriteRepository workerWriteRepository;

        public WorkerService(IWorkerReadRepository workerReadRepository, IMapper mapper, IUnitOfWork unitOfWork, IWorkerWriteRepository workerWriteRepository)
        {
            this.workerReadRepository = workerReadRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.workerWriteRepository = workerWriteRepository;
        }

        async Task<IEnumerable<WorkerModel>> IWorkerService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await workerReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<WorkerModel>>(result);
        }

        async Task<WorkerModel?> IWorkerService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await workerReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }
            return mapper.Map<WorkerModel>(item);
        }

        async Task<WorkerModel> IWorkerService.AddAsync(WorkerRequestModel worker, CancellationToken cancellationToken)
        {
            var item = new Worker
            {
                Id = Guid.NewGuid(),
                FIO = worker.FIO,
                Email = worker.Email,
                Phone = worker.Phone,
                Login = worker.Login,
                Password = worker.Password,
                Birthday = worker.Birthday,
                Passport = worker.Passport,
                Posts = (Posts)worker.Posts,
            };

            workerWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WorkerModel>(item);
        }

        async Task<WorkerModel> IWorkerService.UpdateAsync(WorkerRequestModel source, CancellationToken cancellationToken)
        {
            var targetWorker = await workerReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetWorker == null)
            {
                throw new HotelEntityNotFoundException<Worker>(source.Id);
            }
            targetWorker.FIO = source.FIO;
            targetWorker.Email = source.Email;
            targetWorker.Phone = source.Phone;
            targetWorker.Login = source.Login;
            targetWorker.Password = source.Password;
            targetWorker.Birthday = source.Birthday;
            targetWorker.Passport = source.Passport;
            targetWorker.Posts = (Posts)source.Posts;

            workerWriteRepository.Update(targetWorker);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<WorkerModel>(targetWorker);
        }

        async Task IWorkerService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetWorker = await workerReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetWorker == null)
            {
                throw new HotelEntityNotFoundException<Worker>(id);
            }
            if (targetWorker.DeletedAt.HasValue)
            {
                throw new HotelInvalidOperationException($"Персона с идентификатором {id} уже удален");
            }

            workerWriteRepository.Delete(targetWorker);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
