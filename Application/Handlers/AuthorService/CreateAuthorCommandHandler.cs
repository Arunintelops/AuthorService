using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthorService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AuthorService
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAuthorCommandHandler> _logger;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<CreateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = _mapper.Map<Author>(request);

            /*****************************************************************************/
            var generatedAuthor = await _authorRepository.AddAsync(authorEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedAuthor} successfully created.");
            return generatedAuthor.Id;
        }
    }
}
