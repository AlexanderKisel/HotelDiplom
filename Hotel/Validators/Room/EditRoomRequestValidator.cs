using FluentValidation;
using Hotel.ModelsRequest.Room;

namespace Hotel.Api.Validators.Room
{
    public class EditRoomRequestValidator : AbstractValidator<EditRoomRequest>
    {
        public EditRoomRequestValidator() 
        {
            RuleFor(room => room.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("ID не должен быть пустым");
            RuleFor(room => room.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Номер комнаты(номера) не должен быть пустым или 0");
            RuleFor(room => room.NumberOfSeats)
                .NotNull()
                .NotEmpty()
                .WithMessage("Кол-во мест в номере не должно быть пустым ил 0");
            RuleFor(room => room.NumberOfRooms)
                .NotNull()
                .NotEmpty()
                .WithMessage("Колв-во комнат не должно быть пустым или 0");
            RuleFor(room => room.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Цена не должна быть пустой");
            RuleFor(room => room.TypeRooms)
                .NotNull()
                .NotEmpty()
                .WithMessage("Тип комнаты не должен быть пустым");
        }
    }
}
