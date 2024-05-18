using FluentValidation;
using Hotel.ModelsRequest.Worker;

namespace Hotel.Api.Validators.Worker
{
    public class EditWorkerRequestValidator : AbstractValidator<EditWorkerRequest>
    {
        public EditWorkerRequestValidator() 
        {
            RuleFor(worker => worker.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("ID не должно быть пустым");
            RuleFor(worker => worker.FIO)
                .NotNull()
                .NotEmpty()
                .WithMessage("ФИО не должно быть пустым");
            RuleFor(worker => worker.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Электронная почта не должна быть пустой");
            RuleFor(worker => worker.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Телефон не должен быть пустым");
            RuleFor(worker => worker.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("Логин не должен быть пустым");
            RuleFor(worker => worker.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Пароль не должен быть пустым");
            RuleFor(worker => worker.Passport)
                .NotNull()
                .NotEmpty()
                .WithMessage("Паспорт не должен быть пустым");
            RuleFor(worker => worker.Posts)
                .NotNull()
                .NotEmpty()
                .WithMessage("Должность не должна быть пустой");
        }
    }
}
