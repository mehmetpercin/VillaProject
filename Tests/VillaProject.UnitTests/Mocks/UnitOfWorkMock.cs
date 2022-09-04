using Moq;
using VillaProject.Application.Repositories;

namespace VillaProject.UnitTests.Mocks
{
    public static class UnitOfWorkMock
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepository = ProductRepositoryMock.GetProductRepository();

            mockUow.Setup(r => r.Products).Returns(mockProductRepository.Object);

            return mockUow;
        }
    }
}
