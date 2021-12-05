using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Commands.Validations
{
    public class UpdateBookCommandValidation : BookValidation<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            ValidateName();
            ValidadeQuantityGreater();


            /*ValidateBirthDate();
            ValidateEmail();*/
        }

    }
}