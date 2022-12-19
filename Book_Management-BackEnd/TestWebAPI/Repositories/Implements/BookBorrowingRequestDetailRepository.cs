using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookBorrowingRequestDetailRepository : BaseRepository<BookBorrowingRequestDetails>, IBookBorrowingRequestDetailRepository
    {
        public BookBorrowingRequestDetailRepository(DBContext context) : base(context)
        {
        }

        public void BulkCreate(List<BookBorrowingRequestDetails> bookBorrowingRequestDetails)
        {
            _dbSet.AddRange(bookBorrowingRequestDetails);
        }

        public List<BookBorrowingRequestDetails> GetAllRequestWithUserDetail(Expression<Func<BookBorrowingRequestDetails, bool>>? predicate)
        {
            var ls = _dbSet.Include(b=> b.Id).Where(predicate);
            return ls.ToList();
        }
    }
}
