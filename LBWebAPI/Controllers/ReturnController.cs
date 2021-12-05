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
        private readonly IBookAppService _bookAppService;

        public ReturnController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        // POST: api/Return/2
        [HttpPost("{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.ReturnBook(id));
        }

    }
}
