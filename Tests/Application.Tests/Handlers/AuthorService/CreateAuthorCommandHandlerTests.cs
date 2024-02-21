using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AuthorService;
using Application.Handlers.AuthorService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthorService
{
    public class CreateAuthorCommandHandlerTests
    {
        private readonly Mock<IAuthorRepository> _authorRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateAuthorCommandHandler>> _logger;

        public CreateAuthorCommandHandlerTests()
        {
            _authorRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateAuthorCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Author>(request))
                .Returns(new Author()); 

            _authorRepository
                .Setup(r => r.AddAsync(It.IsAny<Author>()))
                .ReturnsAsync(new Author { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateAuthorCommandHandler>>();
            var handler = new CreateAuthorCommandHandler(_authorRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
