using AutoMapper;
using Moq;
using Application.Handlers.AuthorService;
using Application.Queries.AuthorService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthorService
{
    public class GetAllAuthorsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfAuthorResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Author> 
        {
            new Author { Id = 1 },
            new Author { Id = 2 }

        };

            var RepositoryMock = new Mock<IAuthorRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllAuthorsQuery();
            var handler = new GetAllAuthorsQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<AuthorResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
