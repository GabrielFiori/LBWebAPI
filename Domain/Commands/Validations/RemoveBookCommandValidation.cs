using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Commands.Validations
{
    public class RemoveBookCommandValidation : BookValidation<RemoveBookCommand>
    {
        public RemoveBookCommandValidation()
        {

        }

    }
}