using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Categories;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public AddCategoryResponse Create(AddCategoryRequest createModel)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
            {
                try
                {
                    var createCategory = new Category
                    {
                        CategoryName = createModel.CategoryName,
                        Description = createModel.Description,
                    };

                    var category = _categoryRepository.Create(createCategory);

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return new AddCategoryResponse
                    {
                        CategoryId = (int)category.CategoryId,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                    };
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteCategory = _categoryRepository.Get(c => c.CategoryId == id);

                    if (deleteCategory != null)
                    {
                        bool result = _categoryRepository.Delete(deleteCategory);

                        _categoryRepository.SaveChanges();

                        transaction.Commit();

                        return result;
                    }

                    return false;
                }
                catch
                {
                    transaction.RollBack();

                    return false;
                }
            }
        }

        public IEnumerable<GetCategoryResponse> GetAll(Paging paging)
        {
            var listCategory = _categoryRepository.GetAll(c => true).Select(category => new GetCategoryResponse
            {
                CategoryId = (int)category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
            });
            return listCategory.Skip((paging.PageNumber - 1) * paging.PageSize)
                               .Take(paging.PageSize)
                               .ToList();
        }

        public GetCategoryResponse GetById(int id)
        {
            var requestCategory = _categoryRepository.Get(p => p.CategoryId == id);

            if (requestCategory != null)
            {
                return new GetCategoryResponse
                {
                    CategoryId = (int)requestCategory.CategoryId,
                    CategoryName = requestCategory.CategoryName,
                    Description = requestCategory.Description,
                };
            }

            return null;
        }

        public UpdateCategoryResponse Update(int id, UpdateCategoryRequest updateModel)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepository.Get(c => c.CategoryId == id);

                    if (category != null)
                    {
                        category.CategoryName = updateModel.CategoryName;
                        category.Description = updateModel.Description;

                        var updatedCategory = _categoryRepository.Update(category);

                        _categoryRepository.SaveChanges();
                        transaction.Commit();

                        return new UpdateCategoryResponse
                        {
                            CategoryId = (int)updatedCategory.CategoryId,
                            CategoryName = updatedCategory.CategoryName,
                            Description = updatedCategory.Description,
                        };
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
            }
        }
    }
}