using FluentValidation;


namespace Gap.IPM.Application.InsurancePolicies.Commands.DeleteInsurancePolicy
{
    public class DeleteInsurancePolicyCommandValidator : AbstractValidator<DeleteInsurancePolicyCommand>
    {

        public DeleteInsurancePolicyCommandValidator()
        {
            RuleFor(v => v.InsurancePolicyId)
                .NotEmpty();
        }
    }
}
