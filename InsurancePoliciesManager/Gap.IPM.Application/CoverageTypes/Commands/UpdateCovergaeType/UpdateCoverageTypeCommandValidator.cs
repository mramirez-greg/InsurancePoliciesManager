using FluentValidation;

namespace Gap.IPM.Application.CoverageTypes.Commands.UpdateCovergaeType
{
    public class UpdateCoverageTypeCommandValidator : AbstractValidator<UpdateCoverageTypeCommand>
    {
        public UpdateCoverageTypeCommandValidator()
        {
            RuleFor(v => v.CoverageTypeName)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }           
    }
}
