using System.Linq.Expressions;
using Test.Data.Entities;

namespace TestWebAPI.Repositories.Interfaces
{
    public interface IBookBorrowingRequestRepository : IBaseRepository<BookBorrowingRequest>
    {
        List<BookBorrowingRequest> GetAllRequestWithUserDetail(Expression<Func<BookBorrowingRequest, bool>>? predicate);
    }
}