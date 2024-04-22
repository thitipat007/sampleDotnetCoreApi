using FluentValidation;

namespace sampleDotnetCoreApi.Api.Core.Validators
{
    public class OrderIdValidator : AbstractValidator<int>
    {
        public OrderIdValidator()
        {
            RuleFor(id => id).GreaterThan(0).WithMessage("Order ID must be greater than 0.");
        }
    }
}