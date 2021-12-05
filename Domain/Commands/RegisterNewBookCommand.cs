using Domain.Commands.Validations;
using Domain.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
