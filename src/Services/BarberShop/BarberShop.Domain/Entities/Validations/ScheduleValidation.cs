using FluentValidation;

namespace BarberShop.Domain
{
    public class ScheduleValidation : AbstractValidator<Service>
    {
        public ScheduleValidation()
        {
            RuleFor(p => p.Customer)
                .NotEmpty()
                    .WithMessage("Error Customer is required")
                .Length(min: 2, max: 100)
                    .WithMessage("The Customer field needs to have beetween {MinLength} and {MaxLength} characters");

        }
    }
}
