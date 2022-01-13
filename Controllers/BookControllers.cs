using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAspNetCoreBRGAAP.Models;
using WebApiAspNetCoreBRGAAP.Repositories;

namespace WebApiAspNetCoreBRGAAP.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BooksController : ControllerBase
        {
            private readonly Interface _bookRepository;
            public BooksController(Interface bookRepository)
            {
                _bookRepository = bookRepository;
            }

            [HttpGet]
            public async Task<IEnumerable<Category>> GetBooks()
            {
                return await _bookRepository.Get();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Category>> GetBooks(int id)
            {
                return await _bookRepository.Get(id);
            }

            [HttpPost]
            public async Task<ActionResult<Category>> PostBooks([FromBody] Category book)
            {
                var newBook = await _bookRepository.Create(book);
                return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
            }

            [HttpDelete("{id}")]

            public async Task<ActionResult> Delete(int id)
            {
                var bookToDelete = await _bookRepository.Get(id);

                if (bookToDelete == null)
                    return NotFound();

                await _bookRepository.Delete(bookToDelete.Id);
                return NoContent();


            }

            [HttpPut]
            public async Task<ActionResult> PutBooks(int id, [FromBody] Category book)
            {
                if (id != book.Id)
                    return BadRequest();

                await _bookRepository.Update(book);

                return NoContent();
            }
        }
    }
