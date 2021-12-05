using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Commands.Validations
{
    public class RegisterNewBookCommandValidation : BookValidation<RegisterNewBookCommand>
    {
        public RegisterNewBookCommandValidation()
        {
            ValidateName();
            ValidadeQuantityGreater();


            /*ValidateBirthDate();
            ValidateEmail();*/
        }

    }
}