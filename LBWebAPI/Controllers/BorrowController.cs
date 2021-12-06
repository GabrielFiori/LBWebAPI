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
    public class BorrowController : ApiController
    {
        private readonly IBookQueriesAppService _bookQueriesAppService;
        private readonly IBookCommandAppService _bookCommandAppService;

        public BorrowController(IBookQueriesAppService bookQueriesAppService, IBookCommandAppService bookCommandAppService)
        {
            _bookQueriesAppService = bookQueriesAppService;
            _bookCommandAppService = bookCommandAppService;
        }

        // GET: api/borrow
        [HttpGet("/api/borrowedbooks/")]
        public async Task<IEnumerable<BookApiModel>> GetBook()
        {
            return await _bookQueriesAppService.GetAllBorrowed();
        }

        // POST: api/Borrow/2
        [HttpPost("/api/borrow/book/{id}")]
        public async Task<IActionResult> BorrowBook(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookCommandAppService.BorrowBook(id));
        }

    }
}
