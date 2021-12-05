using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class BookCommand : IRequest<ValidationResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public void AddErrors(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    
    }



    

    
}
