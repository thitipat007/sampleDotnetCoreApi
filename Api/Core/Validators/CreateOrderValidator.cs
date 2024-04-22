
using FluentValidation;
using sampleDotnetCoreApi.Api.Core.Models.Request;

namespace sampleDotnetCoreApi.Api.Core.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(createOrderRequest => createOrderRequest.customer_id).GreaterThan(0).WithMessage("Order ID must be greater than 0.");
            RuleFor(createOrderRequest => createOrderRequest.order_items)
                .Must(e => e.Count > 0)
                .WithMessage("Order Item Must Not Empty.");

        }
    }
}