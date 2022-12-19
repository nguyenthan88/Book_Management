using System.Linq.Expressions;
using Test.Data.Entities;

namespace TestWebAPI.Repositories.Interfaces
{
    public interface IBookBorrowingRequestDetailRepository : IBaseRepository<BookBorrowingRequestDetails>
    {
        List<BookBorrowingRequestDetails> GetAllRequestWithUserDetail(Expression<Func<BookBorrowingRequestDetails, bool>>? predicate);

        void BulkCreate(List<BookBorrowingRequestDetails> bookBorrowingRequestDetails);
    }
}