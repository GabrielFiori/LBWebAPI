using Domain.Commands.Validations;
using FluentValidation.Results;

namespace Domain.Commands
{
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public bool IsValid()
        {
            ValidationResult = new UpdateBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
