using Domain.Commands.Validations;
using FluentValidation.Results;


namespace Domain.Commands
{
    public class ReturnBookCommand : BookCommand
    {
        public ReturnBookCommand(int id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            ValidationResult = new ReturnBookCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
