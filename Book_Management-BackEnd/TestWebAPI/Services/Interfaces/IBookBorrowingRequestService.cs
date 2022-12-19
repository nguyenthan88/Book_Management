using TestWebAPI.Models.Books;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;
using System.Linq.Expressions;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        CreateReponse Create(CreateRequest createRequest);

        IEnumerable<CreateRequest> GetAllRequestWithUserDetail(Paging paging);

        IEnumerable<CreateRequest> GetAll(Expression<Func<BookBorrowingRequest, bool>>? predicate, Paging? paging, bool isPaging);

        void Update(int id, CreateRequest updateRequest);

        bool Delete(int id);
    }
}