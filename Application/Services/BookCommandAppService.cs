using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ApiModels;
using Application.Interface;
using AutoMapper;
using Domain.Commands;
using Domain.Interface;
using FluentValidation.Results;
using MediatR;

namespace Application.Services
{
    public class BookCommandAppService : IBookCommandAppService
    {
        private readonly IMapper _autoMapper;
        private readonly IMediator _mediator;
        
        public BookCommandAppService(IMapper autoMapper, IMediator mediator)
        {
            _autoMapper = autoMapper;
            _mediator = mediator;
        }
        
        public async Task<ValidationResult> RegisterNewBook(BookApiModel book)
        {
            RegisterNewBookCommand newBookCommand = _autoMapper.Map<RegisterNewBookCommand>(book);
            return await _mediator.Send(newBookCommand);
        }

        public async Task<ValidationResult> UpdateBook(BookApiModel book)
        {
            UpdateBookCommand newBookCommand = _autoMapper.Map<UpdateBookCommand>(book);
            return await _mediator.Send(newBookCommand);
        }
        

        public async Task<ValidationResult> RemoveBook(int id)
        {
            RemoveBookCommand removeCommand = new(id);
            return await _mediator.Send(removeCommand);
        }

        public async Task<ValidationResult> BorrowBook(int id)
        {
            BorrowBookCommand borrowCommand = new(id);
            return await _mediator.Send(borrowCommand);
        }

        public async Task<ValidationResult> ReturnBook(int id)
        {
            ReturnBookCommand returnCommand = new(id);
            return await _mediator.Send(returnCommand);
        }
    }
}
