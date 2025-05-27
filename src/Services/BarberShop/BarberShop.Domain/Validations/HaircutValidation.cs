using BarberShop.Core.Notifications;
using FluentValidation;

namespace BarberShop.Domain.Validations
{
    public class HaircutValidation : AbstractValidator<Haircut>
    {
        public HaircutValidation() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage(BarberShopErrorMessage.ERROR_NAME_REQUIRED)
                .Length(min: 2, max: 50)
                    .WithMessage(BarberShopErrorMessage.ERROR_NAME_LENGTH);

            RuleFor(p => p.Price)
                .NotEqual(0)
                    .WithMessage(BarberShopErrorMessage.ERROR_VALUE_PRICE);

            RuleFor(p => p.UserId)
                .NotEmpty()
                    .WithMessage(BarberShopErrorMessage.ERROR_USER_ID);
        }
    }
}
