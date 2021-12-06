using Application.ApiModels;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IBookQueriesAppService
    {
        Task<IEnumerable<BookApiModel>> GetAll();
        Task<BookApiModel> GetById(int id);
        Task<IEnumerable<BookApiModel>> GetAllBorrowed();
    }
}
