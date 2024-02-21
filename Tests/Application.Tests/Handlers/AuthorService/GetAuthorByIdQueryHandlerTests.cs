using AutoMapper;
using Moq;
using Application.Handlers.AuthorService;
using Application.Queries.AuthorService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthorService
{
    public class GetAuthorByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsAuthorResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Author { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IAuthorRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetAuthorByIdQuery(Id);
            var handler = new GetAuthorByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AuthorResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
