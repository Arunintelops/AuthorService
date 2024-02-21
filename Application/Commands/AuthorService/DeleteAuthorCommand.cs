using MediatR;

namespace Application.Commands.AuthorService
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
