using TestWebAPI.Models;
using TestWebAPI.Models.Books;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        AddBookResponse Create(AddBookRequest createModel);

        IEnumerable<GetBookResponse> GetAll(Paging paging);

        GetBookResponse GetById(int id);

        UpdateBookResponse Update(int id, UpdateBookRequest updateModel);

        bool Delete(int id);
    }
}