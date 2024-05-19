using FluentValidation;
using Hotel.ModelsRequest.Menu;

namespace Hotel.Api.Validators.Menu
{
    public class CreateMenuRequestValidator : AbstractValidator<CreateMenuRequest>
    {
        public CreateMenuRequestValidator() 
        {
            RuleFor(menu => menu.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Название блюда не должно быть пустым");
            RuleFor(menu => menu.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Цена блюда не должна быть пустой");
            RuleFor(menu => menu.TypeEat)
                .NotNull()
                .NotEmpty()
                .WithMessage("Тип блюда блюда не должен быть пустой");
        }
    }
}
