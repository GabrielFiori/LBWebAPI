using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ApiModels;
using Application.Services;
using Repository.Interface;
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

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookApiModel bookApiModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookAppService.RegisterNewBook(bookApiModel));
        }


        // GET: api/Books/2
        [HttpGet("{id}")]
        public async Task<BookApiModel> GetBook(int id)
        {
            return await _bookAppService.GetById(id);
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



        /*public async Task<BookApiModel> RegisterBook(BookApiModel book)
        {
            return await _bookAppService.RegisterBook(book);
        }

        
        /*[HttpGet("{id}")]
        public async Task<ActionResult<BookApiModel>> GetBook(int id)
        {
            //var book = await _context.Book.FindAsync(id);

            //if (book == null)
            //{
            //    return NotFound();
            //}

            //return book;
        }

        /*
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookApiModel book)
        {
            /*if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookApiModel>> PostBook(BookApiModel book)
        {
            /*book.Id = 0;
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            /*var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool BookExists(int id)
        {
            /*return _context.Book.Any(e => e.Id == id);
        }*/
    }
    }
