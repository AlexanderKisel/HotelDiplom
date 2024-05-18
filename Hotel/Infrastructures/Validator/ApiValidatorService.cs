using FluentValidation;
using Hotel.Api.Validators.Booking;
using Hotel.Api.Validators.Menu;
using Hotel.Api.Validators.Person;
using Hotel.Api.Validators.Room;
using Hotel.Api.Validators.Worker;
using Hotel.Repositories.Contracts.Interface;
using Hotel.Services.Contracts.Exceptions;
using Hotel.Shared;

namespace Hotel.Infrastructures.Validator
{
    internal sealed class ApiValidatorService : IApiValidatorService
    {
        private readonly Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        public ApiValidatorService(IWorkerReadRepository workerReadRepository,
            IPersonReadRepository personReadRepository,
            IRoomReadRepository roomReadRepository) 
        {
            Register<CreateMenuRequestValidator>();
            Register<EditMenuRequestValidator>();

            Register<CreateWorkerRequestValidator>();
            Register<EditWorkerRequestValidator>();

            Register<CreatePersonRequestValidator>();
            Register<EditPersonRequestValidator>();

            Register<CreateRoomRequestValidator>();
            Register<EditRoomRequestValidator>();

            Register<CreateBookingRequestValidator>(workerReadRepository, personReadRepository, roomReadRepository);
            Register<EditBookingRequestValidator>(workerReadRepository, personReadRepository, roomReadRepository);
        }

        ///<summary>
        /// Регистрирует валидатор в словаре
        /// </summary>
        public void Register<TValidator>(params object[] constructorParams)
            where TValidator : IValidator
        {
            var validatorType = typeof(TValidator);
            var innerType = validatorType.BaseType?.GetGenericArguments()[0];
            if (innerType == null)
            {
                throw new ArgumentNullException($"Указанный валидатор {validatorType} должен быть generic от типа IValidator");
            }

            if (constructorParams?.Any() == true)
            {
                var validatorObject = Activator.CreateInstance(validatorType, constructorParams);
                if (validatorObject is IValidator validator)
                {
                    validators.TryAdd(innerType, validator);
                }
            }
            else
            {
                validators.TryAdd(innerType, Activator.CreateInstance<TValidator>());
            }
        }
        public async Task ValidateAsync<TModel>(TModel model, CancellationToken cancellationToken)
            where TModel : class
        {
            var modelType = model.GetType();
            if (!validators.TryGetValue(modelType, out var validator))
            {
                throw new InvalidOperationException($"Не найден валидатор для модели {modelType}");
            }

            var context = new ValidationContext<TModel>(model);
            var result = await validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new HotelValidationException(result.Errors.Select(x =>
                InvalidateItemModel.New(x.PropertyName, x.ErrorMessage)));
            }
        }
    }
}
