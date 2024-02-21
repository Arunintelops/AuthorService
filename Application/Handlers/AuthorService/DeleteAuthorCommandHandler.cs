using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthorService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AuthorService
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<DeleteAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToDelete = await _authorRepository.GetByIdAsync(request.Id);
            if (authorToDelete == null)
            {
                throw new AuthorNotFoundException(nameof(Author), request.Id);
            }

            await _authorRepository.DeleteAsync(authorToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
