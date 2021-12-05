using FluentValidation;

namespace Domain.Commands.Validations
{
    public abstract class BookValidation<T> : AbstractValidator<T> where T : BookCommand
    {
           
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters")
                .Matches("^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$").WithMessage("Special characters are not allowed");
        }

        protected void ValidadeQuantityGreater()
        {
            RuleFor(c => c.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1");
        }

    }
}
