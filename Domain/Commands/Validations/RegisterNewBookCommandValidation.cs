

namespace Domain.Commands.Validations
{
    public class RegisterNewBookCommandValidation : BookValidation<RegisterNewBookCommand>
    {
        public RegisterNewBookCommandValidation()
        {
            ValidateName();
            ValidadeQuantityGreater();
        }

    }
}