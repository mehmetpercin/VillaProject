using Moq;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.UnitTests.Mocks
{
    public static class ProductRepositoryMock
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            CancellationToken cancellationToken = new CancellationToken();
            var products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Name = "Product 1",
                    CategoryId = 1,
                    Price = 1,
                    IsActive = true
                },
                new Product
                {
                    Id=2,
                    Name = "Product 2",
                    CategoryId = 2,
                    Price = 2,
                    IsActive = true
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(x => x.GetAll(false).ToList()).Returns(products);
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Product>(), cancellationToken)).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });
            mockRepo.Setup(x => x.UpdateAsync(It.IsAny<Product>(), cancellationToken));
            mockRepo.Setup(x => x.RemoveAsync(It.IsAny<Product>(), cancellationToken));
            //mockRepo.Setup(x => x.GetFirstAsync(It.IsAny<Expression<Func<Product, bool>>>(), cancellationToken, false)).ReturnsAsync(products.First());
            //mockRepo.Setup(x => x.GetByFilterAsync(It.IsAny<Expression<Func<Product, bool>>>(), cancellationToken, false)).ReturnsAsync(products);


            return mockRepo;
        }
    }
}
