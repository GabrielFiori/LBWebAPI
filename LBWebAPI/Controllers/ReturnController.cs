using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Interface;
using LBWebAPI.Controllers;

namespace BibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ApiController
    {
        private readonly IBookCommandAppService _bookCommandAppService;

        public ReturnController( IBookCommandAppService bookCommandAppService)
        {
            _bookCommandAppService = bookCommandAppService;
        }

        // POST: api/Return/2
        [HttpPost("/api/return/book/{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookCommandAppService.ReturnBook(id));
        }

    }
}
