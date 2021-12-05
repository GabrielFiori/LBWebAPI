﻿using Application.ApiModels;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IBookAppService
    {
        Task<IEnumerable<BookApiModel>> GetAll();
        Task<BookApiModel> GetById(int id);
        Task<ValidationResult> RegisterNewBook(BookApiModel book);
        Task<ValidationResult> UpdateBook(BookApiModel book);
        Task<ValidationResult> RemoveBook(int id);
        Task<ValidationResult> BorrowBook(int id);
        Task<IEnumerable<BookApiModel>> GetAllBorrowed();
        Task<ValidationResult> ReturnBook(int id);
    }
}
