using System.Linq.Expressions;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Features.Products.Commands.CreateProductCommand;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;
using VillaProject.UnitTests.Mocks;

namespace VillaProject.UnitTests.ApplicationTests.Products.Commands
{
    public class CreateProductCommandRequestHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly CreateProductCommandRequestHandler _createProductCommandRequestHandler;

        public CreateProductCommandRequestHandlerTest()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            _mockUow = RepositoryMocks.GetUnitOfWork();
            _mockUow.Setup(x => x.Products).Returns(_mockProductRepository.Object);
            _mockUow.Setup(x => x.Categories).Returns(_mockCategoryRepository.Object);
            _createProductCommandRequestHandler = new CreateProductCommandRequestHandler(_mockUow.Object);
        }

        [Fact]
        public async Task InValid_CategoryId_ReturnsErrorResponse()
        {
            _mockCategoryRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Category, bool>>>(), CancellationToken.None)).ReturnsAsync(false);
            var result = await _createProductCommandRequestHandler.Handle(new CreateProductCommandRequest { CategoryId = -1, Name = "Product 1", Price = 1 }, CancellationToken.None);

            Assert.IsType<ErrorResult>(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Valid_CategoryId_ReturnsSuccessDataResponsee()
        {
            _mockCategoryRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Category, bool>>>(), CancellationToken.None)).ReturnsAsync(true);

            var result = await _createProductCommandRequestHandler.Handle(new CreateProductCommandRequest { CategoryId = -1, Name = "Product 1", Price = 1 }, CancellationToken.None);
            _mockUow.Verify(x => x.Products.AddAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
            _mockUow.Verify(x => x.SaveAsync(CancellationToken.None), Times.Once);

            Assert.IsType<SuccessDataResult>(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
