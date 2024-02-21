using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.AuthorService;
using Application.Queries.AuthorService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthorServiceController> _logger;
        public AuthorServiceController(IMediator mediator, ILogger<AuthorServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateAuthor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllAuthors")]
        [ProducesResponseType(typeof(IEnumerable<List<AuthorResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AuthorResponse>>> GetAllAuthors(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAuthorsQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetAuthorById")]
        [ProducesResponseType(typeof(AuthorResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AuthorResponse>> GetAuthorById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Author GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetAuthorByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            _logger.LogInformation("Author DELETE request received for ID {id}", id);
            var cmd = new DeleteAuthorCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
