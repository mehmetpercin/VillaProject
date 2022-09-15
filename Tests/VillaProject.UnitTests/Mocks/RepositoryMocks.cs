using Moq;
using VillaProject.Application.Repositories;

namespace VillaProject.UnitTests.Mocks
{
    public static class RepositoryMocks
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveAsync(CancellationToken.None));

            return mockUow;
        }

        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            return mockOrderRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var mockCategoryRepository = new Mock<ICategoryRepository>();

            return mockCategoryRepository;
        }

        public static Mock<IProductRepository> GetProductRepository()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            return mockProductRepository;
        }
    }
}
