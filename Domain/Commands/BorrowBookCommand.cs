using Domain.Commands.Validations;
using FluentValidation.Results;


namespace Domain.Commands
{
    public class BorrowBookCommand : BookCommand
    {
        public BorrowBookCommand(int id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            ValidationResult = new BorrowBookCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
