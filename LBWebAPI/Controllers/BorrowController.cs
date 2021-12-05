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
        private readonly IBookAppService _bookAppService;

        public BorrowController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        // GET: api/Borrow
        [HttpGet]
        public async Task<IEnumerable<BookApiModel>> GetBook()
        {
            return await _bookAppService.GetAllBorrowed();
        }

        // POST: api/Borrow/2
        [HttpPost("{id}")]
        public async Task<IActionResult> BorrowBook(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.BorrowBook(id));
        }

    }
}
