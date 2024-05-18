using FluentValidation;
using Hotel.ModelsRequest.Person;

namespace Hotel.Api.Validators.Person
{
    public class CreatePersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonRequestValidator() 
        {
            RuleFor(person => person.FIO)
                .NotNull()
                .NotEmpty()
                .WithMessage("ФИО не должно быть пустым");
            RuleFor(person => person.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Электронная почта не должна быть пустой");
            RuleFor(person => person.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Телефон не должен быть пустым");
            RuleFor(person => person.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("Логин не должен быть пустым");
            RuleFor(person => person.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Пароль не должен быть пустым");
        }
    }
}
