using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }*/
    }
}
