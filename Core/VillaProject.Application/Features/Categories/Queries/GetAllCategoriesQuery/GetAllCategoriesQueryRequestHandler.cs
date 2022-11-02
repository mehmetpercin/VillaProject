using MediatR;
using VillaProject.Application.Dtos.Categories;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryRequestHandler : IRequestHandler<GetAllCategoriesQueryRequest, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await Task.Run(() =>
            {
                return _categoryRepository.GetAll().Select(x => new CategoryDto
                {
                    Id = x.Id.ToString(),
                    Name = x.Name
                }).ToList();
            });

            return SuccessDataResult.Success(categories, 200);
        }
    }
}
