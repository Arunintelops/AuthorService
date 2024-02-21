using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthorService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.AuthorService
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<UpdateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = await _authorRepository.GetByIdAsync(request.Id);
            if (authorToUpdate == null)
            {
                throw new AuthorNotFoundException(nameof(Author), request.Id);
            }

            _mapper.Map(request, authorToUpdate, typeof(UpdateAuthorCommand), typeof(Author));
            await _authorRepository.UpdateAsync(authorToUpdate);
            _logger.LogInformation($"Author is successfully updated");
        }
    }
}
