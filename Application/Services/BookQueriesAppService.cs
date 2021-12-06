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
    public class BookQueriesAppService : IBookQueriesAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _autoMapper;
        
        public BookQueriesAppService(IBookRepository bookRepository, IMapper autoMapper)
        {
            _bookRepository = bookRepository;
            _autoMapper = autoMapper;
        }
        
        public async Task<IEnumerable<BookApiModel>> GetAll()
        {
            return await Task.FromResult(_autoMapper.Map<IEnumerable<BookApiModel>>(_bookRepository.GetAll()));
        }

        public async Task<BookApiModel> GetById(int id)
        {
            return await Task.FromResult(_autoMapper.Map<BookApiModel>(_bookRepository.GetById(id)));
        }

        public async Task<IEnumerable<BookApiModel>> GetAllBorrowed()
        {
            return await Task.FromResult(_autoMapper.Map<IEnumerable<BookApiModel>>(_bookRepository.GetAllBorrowed()));
        }

    }
}
