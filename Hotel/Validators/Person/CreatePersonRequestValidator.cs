using FluentValidation;
using Hotel.ModelsRequest.Person;
using Hotel.Repositories.Contracts.Interface;

namespace Hotel.Api.Validators.Person
{
    public class CreatePersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonRequestValidator(IPersonReadRepository personReadRepository) 
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
                .WithMessage("Телефон не должен быть пустым")
                .MustAsync(async (phone, cancellationToken) =>
                {
                    var isPhoneExists = await personReadRepository.AnyByPhoneAsync(phone, cancellationToken);
                    return !isPhoneExists;
                })
                .WithMessage("Телефон уже используется");
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
