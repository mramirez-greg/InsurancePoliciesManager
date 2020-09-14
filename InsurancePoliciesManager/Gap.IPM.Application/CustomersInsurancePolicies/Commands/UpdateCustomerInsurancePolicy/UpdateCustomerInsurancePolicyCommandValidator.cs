using FluentValidation;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Commands.UpdateCustomerInsurancePolicy
{
    public class UpdateCustomerInsurancePolicyCommandValidator : AbstractValidator<UpdateCustomerInsurancePolicyCommand>
    {
        public UpdateCustomerInsurancePolicyCommandValidator()
        {
            RuleFor(v => v.CustomerInsurancePolicyId)
              .NotNull().WithMessage("Id is required.");           
            RuleFor(v => v.Status)
                .NotNull();
            RuleFor(v => v.StatusDate)
                .NotNull();
        }
    }
}
