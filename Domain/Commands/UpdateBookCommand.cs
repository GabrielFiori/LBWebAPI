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
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public bool IsValid()
        {
            ValidationResult = new UpdateBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
