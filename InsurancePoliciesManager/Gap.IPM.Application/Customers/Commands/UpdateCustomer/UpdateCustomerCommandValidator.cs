using FluentValidation;

namespace Gap.IPM.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(v => v.CustomerId)
               .NotEmpty().WithMessage("CustomerId is required.")
               .MaximumLength(50).WithMessage("CustomerId must not exceed 50 characters.");
            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters.");
            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(200).WithMessage("LastName must not exceed 200 characters.");
            RuleFor(v => v.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address must not exceed 500 characters.");
            RuleFor(v => v.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(20).WithMessage("Phone must not exceed 20 characters.");
            RuleFor(v => v.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City must not exceed 50 characters.");
            RuleFor(v => v.Region)
                .NotEmpty().WithMessage("Region is required.")
                .MaximumLength(50).WithMessage("Region must not exceed 50 characters.");
            RuleFor(v => v.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");
            RuleFor(v => v.PostalCode)
                .NotEmpty().WithMessage("PostalCode is required.")
                .MaximumLength(10).WithMessage("PostalCode must not exceed 10 characters.");
        }
    }
}
