using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Interfaces;

namespace TestWebAPI.Repositories.Implements
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(DBContext context) : base(context)
        {
        }

        public List<BookBorrowingRequest> GetAllRequestWithUserDetail(Expression<Func<BookBorrowingRequest, bool>>? predicate)
        {
            var ls = _dbSet
                    .Include(x => x.RequestedBy)
                    .Include(b => b.ProcessedBy)
                    .Where(predicate);
            return ls.ToList();
        }
    }
}
