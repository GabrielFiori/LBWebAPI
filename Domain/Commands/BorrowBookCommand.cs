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
