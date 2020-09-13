using FluentValidation;

namespace Gap.IPM.Application.CoverageTypes.Commands.CreateCoverageType
{
    public class CreateCoverageTypeCommandValidator:AbstractValidator<CreateCoverageTypeCommand>
    {
        public CreateCoverageTypeCommandValidator()
        {
            RuleFor(v => v.CoverageTypeName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        }
    }
}
