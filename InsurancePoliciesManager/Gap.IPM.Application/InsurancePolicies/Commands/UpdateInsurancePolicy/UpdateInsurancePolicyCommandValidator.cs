﻿using FluentValidation;
using Gap.IPM.Domain.Enums;

namespace Gap.IPM.Application.InsurancePolicies.Commands.UpdateInsurancePolicy
{
    public class UpdateInsurancePolicyCommandValidator : AbstractValidator<UpdateInsurancePolicyCommand>
    {
        public UpdateInsurancePolicyCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
            RuleFor(v => v.Coverage)
                .GreaterThan(0)
                .WithMessage("Coverage percentage must be greater than 0%");
            RuleFor(v => v.CoveragePeriod)
               .GreaterThan(0)
               .WithMessage("Coverage Period  must be greater than 0");
            RuleFor(v => v.PolicyValue)
               .GreaterThan(0)
               .WithMessage("Policy Value must be greater than $0");

            //business rule for application defined by GAP's Exercise document
            When(v => v.RiskType.Equals(RiskType.Alto), () => {
                RuleFor(v => v.Coverage).LessThanOrEqualTo(0.5M).WithMessage("Coverage percentage can't be greater than 50");
            });
        }

    }
}
