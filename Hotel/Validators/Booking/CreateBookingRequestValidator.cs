using FluentValidation;
using Hotel.ModelsRequest.Booking;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Api.Validators.Booking
{
    public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
    {
        public CreateBookingRequestValidator(IRoomReadRepository roomReadRepository,
            IWorkerReadRepository workerReadRepository,
            IPersonReadRepository personReadRepository)
        {
            RuleFor(booking => booking.RoomId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Номер комнаты не должен быть пустым")
                .MustAsync(async (id, cancellationToken) =>
                {
                    var room = await roomReadRepository.AnyByIdAsync(id, cancellationToken);
                    return room;
                })
                .WithMessage("Такого номера не существует");
            RuleFor(booking => booking.DateReg)
                .NotNull()
                .NotEmpty()
                .WithMessage("Дата регистрации не должна быть пустой");
            RuleFor(booking => booking.DateStart)
                .NotNull()
                .NotEmpty()
                .WithMessage("Дата начала бронирования не должна быть пустой");
            RuleFor(booking => booking.DateReg)
                .NotNull()
                .NotEmpty()
                .WithMessage("Дата окончания бронирования не должна быть пустой");
        }
    }
}
