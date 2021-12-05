using Domain.Commands.Validations;
using FluentValidation.Results;


namespace Domain.Commands
{
    public class RegisterNewBookCommand : BookCommand
    {
        public RegisterNewBookCommand(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public bool IsValid()
        {
            ValidationResult = new RegisterNewBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
