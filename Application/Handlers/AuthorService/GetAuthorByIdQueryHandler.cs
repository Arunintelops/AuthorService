using AutoMapper;
using MediatR;
using Application.Queries.AuthorService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AuthorService
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedAuthor = await _authorRepository.GetByIdAsync(request.id);
            var authorEntity = _mapper.Map<AuthorResponse>(generatedAuthor);
            return authorEntity;
        }
    }
}
