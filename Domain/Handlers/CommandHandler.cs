using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Models;
using Domain.Interface;
using MediatR;
using FluentValidation.Results;


namespace Domain.Handlers
{
    public class CommandHandler :   IRequestHandler<RegisterNewBookCommand, ValidationResult>,
                                    IRequestHandler<UpdateBookCommand, ValidationResult>,
                                    IRequestHandler<RemoveBookCommand, ValidationResult>,
                                    IRequestHandler<BorrowBookCommand, ValidationResult>,
                                    IRequestHandler<ReturnBookCommand, ValidationResult>

    {
        private readonly IBookRepository _bookRepository;
        
        public CommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<ValidationResult> Handle(RegisterNewBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(request.ValidationResult);

            if (_bookRepository.GetByName(request.Name) != null)
            {
                request.AddErrors("The Book Name is already Registered.");
                return Task.FromResult(request.ValidationResult);
            }

            int newID = _bookRepository.GetNewId();

            Book newBook = new(newID, request.Name, request.Quantity);

            //[TODO] Create Domain Event.

            _bookRepository.Add(newBook);

            return Task.FromResult(request.ValidationResult);
        }

        public Task<ValidationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(request.ValidationResult);

            Book selectedBook = _bookRepository.GetById(request.Id);

            if (selectedBook == null)
            {
                request.AddErrors("id not Found.");
                return Task.FromResult(request.ValidationResult);
            }

            selectedBook.Name = request.Name;
            selectedBook.Quantity = request.Quantity;
            _bookRepository.Update(selectedBook);

            return Task.FromResult(request.ValidationResult);
        }

        public Task<ValidationResult> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(request.ValidationResult);

            if (_bookRepository.GetById(request.Id) == null)
            {
                request.AddErrors("id not Found.");
                return Task.FromResult(request.ValidationResult);
            }

            _bookRepository.Remove(request.Id);

            return Task.FromResult(request.ValidationResult);
        }

        public Task<ValidationResult> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(request.ValidationResult);

            Book borrowBook = _bookRepository.GetById(request.Id);

            if (borrowBook == null)
            {
                request.AddErrors("id not Found.");
                return Task.FromResult(request.ValidationResult);
            }

            if (borrowBook.Quantity == 0)
            {
                request.AddErrors("This Book is not on inventory, wait for return");
                return Task.FromResult(request.ValidationResult);
            }

            _bookRepository.Borrow(borrowBook.Id);

            return Task.FromResult(request.ValidationResult);
        }

        public Task<ValidationResult> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(request.ValidationResult);

            Book returnBook = _bookRepository.GetById(request.Id);

            if (returnBook == null)
            {
                request.AddErrors("id not Found.");
                return Task.FromResult(request.ValidationResult);
            }

            Book borrowedBook = _bookRepository.GetBorrowedById(request.Id);

            if (borrowedBook == null)
            {
                request.AddErrors("This Book is not Borrowed");
                return Task.FromResult(request.ValidationResult);
            }

            _bookRepository.ReturnBook(request.Id);

            return Task.FromResult(request.ValidationResult);
        }
    }
}
