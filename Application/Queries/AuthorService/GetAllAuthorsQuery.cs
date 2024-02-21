using MediatR;
using Application.Responses;

namespace Application.Queries.AuthorService
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorResponse>>
    {

    }
}
