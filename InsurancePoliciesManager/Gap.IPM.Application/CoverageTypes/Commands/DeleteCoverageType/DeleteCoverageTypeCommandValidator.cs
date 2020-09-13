using FluentValidation;

namespace Gap.IPM.Application.CoverageTypes.Commands.DeleteCoverageType
{
    public class DeleteCoverageTypeCommandValidator : AbstractValidator<DeleteCoverageTypeCommand>
    {
        public DeleteCoverageTypeCommandValidator()
        {
            RuleFor(v => v.CoverageTypeId)
                .NotEmpty();
        }
    }
}
