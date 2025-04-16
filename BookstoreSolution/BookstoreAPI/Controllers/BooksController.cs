using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookstoreApplication.Features.Books.Commands;
using BookstoreApplication.Features.Books.Queries;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            return Ok(new { BookId = bookId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery{ Id = id});
            return Ok(book);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var success = await _mediator.Send(command);

            return success ? NoContent() : NotFound();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteBookCommand { Id = id });
            return success ? NoContent() : NotFound();
        }

        [HttpPost("assign-authors")]
        public async Task<IActionResult> AssignAuthorsToBook([FromBody] AssignAuthorsToBooksCommand command)
        {
            var success = await _mediator.Send(command);

            if (!success)
            {
                return NotFound();
            }

            return NoContent(); 
        }
    }
}
