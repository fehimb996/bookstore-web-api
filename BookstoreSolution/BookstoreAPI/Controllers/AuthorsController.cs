using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookstoreApplication.Features.Authors.Commands;
using BookstoreApplication.Features.Authors.Queries;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createAuthor")]
        public async Task<IActionResult> Create(CreateAuthorCommand command)
        {
            var authorId = await _mediator.Send(command);
            return Ok(authorId);
        }

        [HttpGet("getAllAuthors")]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpGet("getAuthor/id")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (author == null)
            {
                return NotFound();
            }
            
            return Ok(author);
        }

        [HttpPut("updateAuthor/id")]
        public async Task<IActionResult> Update(int id, UpdateAuthorCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            var success = await _mediator.Send(command);

            if(!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("deleteAuthor/id")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteAuthorCommand(id));

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
