using FluentValidation;
using Hotel.ModelsRequest.Booking;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Api.Validators.Booking
{
    public class EditBookingRequestValidator : AbstractValidator<EditBookingRequest>
    {
        public EditBookingRequestValidator(IRoomReadRepository roomReadRepository,
            IWorkerReadRepository workerReadRepository,
            IPersonReadRepository personReadRepository) 
        {
            RuleFor(booking => booking.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id не должен быть пустым или null");
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
            RuleFor(booking => booking.WorkerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Поле работника не должно быть пустым")
                .MustAsync(async (id, cancellationToken) =>
                {
                    if (id == null) return true;
                        var worker = await workerReadRepository.AnyByIdAsync(id.Value, cancellationToken);
                        return worker;
                })
                .WithMessage("Такого работника не существует");
            RuleFor(booking => booking.PersonId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Поле персоны не должно быть пустым")
                .MustAsync(async (id, cancellationToken) =>
                {
                    if (id == null) return true;
                    var person = await personReadRepository.AnyByIdAsync(id.Value, cancellationToken);
                    return person;
                })
                .WithMessage("Такой персоны не существует");
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
