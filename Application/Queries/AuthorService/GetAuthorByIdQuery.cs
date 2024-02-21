using MediatR;
using Application.Responses;

namespace Application.Queries.AuthorService
{
    public class GetAuthorByIdQuery : IRequest<AuthorResponse>
    {
        public int id { get; set; }

        public GetAuthorByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
