using Domain.Commands.Validations;
using FluentValidation.Results;


namespace Domain.Commands
{
    public class RemoveBookCommand : BookCommand
    {
        public RemoveBookCommand(int id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            ValidationResult = new RemoveBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
