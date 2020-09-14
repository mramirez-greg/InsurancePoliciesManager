using FluentValidation;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Commands.CreateCustomerInsurancePolicy
{
    public class CreateCustomerInsurancePolicyCommandValidator : AbstractValidator<CreateCustomerInsurancePolicyCommand>
    {
        public CreateCustomerInsurancePolicyCommandValidator()
        {
            RuleFor(v => v.CustomerId)
              .NotEmpty().WithMessage("CustomerId is required.")
              .MaximumLength(50).WithMessage("CustomerId must not exceed 50 characters.");
            RuleFor(v => v.InsurancePolicyId)
                .NotNull();
            RuleFor(v => v.Status)
                .NotNull();

        }
    }
}
