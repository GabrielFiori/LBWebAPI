using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ApiModels;
using Application.Interface;
using LBWebAPI.Controllers;

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ApiController
    {
        private readonly IBookQueriesAppService _bookQueriesAppService;
        private readonly IBookCommandAppService _bookCommandAppService;

        public BooksController(IBookQueriesAppService bookQueriesAppService, IBookCommandAppService bookCommandAppService)
        {
            _bookQueriesAppService = bookQueriesAppService;
            _bookCommandAppService = bookCommandAppService;
        }

        // GET: /api/books/
        [HttpGet("/api/books/")]
        public async Task<IEnumerable<BookApiModel>> GetBook()
        {         
            return await _bookQueriesAppService.GetAll();
        }

        // GET: /api/book/2
        [HttpGet("/api/book/{id}")]
        public async Task<BookApiModel> GetBook(int id)
        {
            return await _bookQueriesAppService.GetById(id);
        }

        // POST: /api/book/
        [HttpPost("/api/book/")]
        public async Task<IActionResult> Post([FromBody] BookApiModel bookApiModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookCommandAppService.RegisterNewBook(bookApiModel));
        }

        // PUT: /api/book/
        [HttpPut("/api/book/")]
        public async Task<IActionResult> UpdateBook([FromBody] BookApiModel bookApiModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookCommandAppService.UpdateBook(bookApiModel));
        }

        // DELETE: /api/book/
        [HttpDelete("/api/book/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookCommandAppService.RemoveBook(id));
        }

    }
}
