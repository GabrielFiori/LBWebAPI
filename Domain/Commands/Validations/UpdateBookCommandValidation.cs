

namespace Domain.Commands.Validations
{
    public class UpdateBookCommandValidation : BookValidation<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            ValidateName();
            ValidadeQuantityGreater();

        }

    }
}