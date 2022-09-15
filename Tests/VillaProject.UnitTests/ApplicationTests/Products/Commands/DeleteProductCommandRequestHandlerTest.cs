using Moq;
using System.Linq.Expressions;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Features.Products.Commands.DeleteProductCommand;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;
using VillaProject.UnitTests.Mocks;

namespace VillaProject.UnitTests.ApplicationTests.Products.Commands
{
    public class DeleteProductCommandRequestHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly DeleteProductCommandRequestHandler _deleteProductCommandRequestHandler;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;

        public DeleteProductCommandRequestHandlerTest()
        {
            _mockOrderRepository = RepositoryMocks.GetOrderRepository();
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            _mockUow = RepositoryMocks.GetUnitOfWork();

            _mockUow.Setup(x => x.Products).Returns(_mockProductRepository.Object);
            _mockUow.Setup(x => x.Orders).Returns(_mockOrderRepository.Object);
            _deleteProductCommandRequestHandler = new DeleteProductCommandRequestHandler(_mockUow.Object);
        }

        [Fact]
        public async Task HasOrderWith_ProductId_ReturnsErrorResponse()
        {
            _mockOrderRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Order, bool>>>(), CancellationToken.None)).ReturnsAsync(true);

            var result = await _deleteProductCommandRequestHandler.Handle(new DeleteProductCommandRequest { Id = 1 }, CancellationToken.None);

            Assert.IsType<ErrorResponse<object>>(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task InValid_ProductId_ReturnsSuccessResponse()
        {
            _mockOrderRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Order, bool>>>(), CancellationToken.None)).ReturnsAsync(false);
            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None, false)).ReturnsAsync(() => null);

            var result = await _deleteProductCommandRequestHandler.Handle(new DeleteProductCommandRequest { Id = 1 }, CancellationToken.None);

            _mockUow.Verify(x => x.Products.RemoveAsync(It.IsAny<Product>(), CancellationToken.None), Times.Never);
            _mockUow.Verify(x => x.SaveAsync(CancellationToken.None), Times.Never);

            Assert.IsType<SuccessResponse>(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Valid_ProductId_ReturnsSuccessResponse()
        {
            _mockOrderRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Order, bool>>>(), CancellationToken.None)).ReturnsAsync(false);

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None, false)).ReturnsAsync(() => new Product());

            var result = await _deleteProductCommandRequestHandler.Handle(new DeleteProductCommandRequest { Id = 1 }, CancellationToken.None);

            _mockUow.Verify(x => x.Products.RemoveAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
            _mockUow.Verify(x => x.SaveAsync(CancellationToken.None), Times.Once);

            Assert.IsType<SuccessResponse>(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
