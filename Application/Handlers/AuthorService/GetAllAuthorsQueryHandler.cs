using AutoMapper;
using MediatR;
using Application.Queries.AuthorService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AuthorService
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<List<AuthorResponse>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var generatedAuthor = await _authorRepository.GetAllAsync();
            var authorEntity = _mapper.Map<List<AuthorResponse>>(generatedAuthor);
            return authorEntity;
        }
    }
}
