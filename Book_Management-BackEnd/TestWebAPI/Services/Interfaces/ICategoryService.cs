using TestWebAPI.Models;
using TestWebAPI.Models.Categories;
namespace TestWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        AddCategoryResponse Create(AddCategoryRequest createModel);

        IEnumerable<GetCategoryResponse> GetAll(Paging paging);

        GetCategoryResponse GetById(int id);

        UpdateCategoryResponse Update(int id, UpdateCategoryRequest updateModel);

        bool Delete(int id);
    }
}