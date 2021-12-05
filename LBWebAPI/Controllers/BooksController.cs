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
        private readonly IBookAppService _bookAppService;

        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<BookApiModel>> GetBook()
        {         
            return await _bookAppService.GetAll();
        }

        // GET: api/Books/2
        [HttpGet("{id}")]
        public async Task<BookApiModel> GetBook(int id)
        {
            return await _bookAppService.GetById(id);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookApiModel bookApiModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.RegisterNewBook(bookApiModel));
        }

        // POST: api/BookUpdate/2
        [HttpPost("/api/BookUpdate/")]
        public async Task<IActionResult> UpdateBook([FromBody] BookApiModel bookApiModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.UpdateBook(bookApiModel));
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.RemoveBook(id));
        }

    }
}
