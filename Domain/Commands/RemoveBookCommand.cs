using Domain.Commands.Validations;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
