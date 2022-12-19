using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestDetailService : IBookBorrowingRequestDetailService
    {
        private readonly IBookBorrowingRequestDetailRepository _bookRequestDetailRepository;
        public BookBorrowingRequestDetailService(IBookBorrowingRequestDetailRepository bookRequestDetailRepository)
        {
            _bookRequestDetailRepository = bookRequestDetailRepository;
        }

        public void BulkCreate(List<CreateRequestDetails> createRequestDetail)
        {
            var bookBorrowingRequestDetails = new List<BookBorrowingRequestDetails>();

            foreach (CreateRequestDetails detail in createRequestDetail)
            {
                bookBorrowingRequestDetails.Add(new BookBorrowingRequestDetails()
                {
                    BookId = detail.BookId,
                    BookBorrowingRequestId = detail.BookBorrowingRequestId,
                });
            }

            _bookRequestDetailRepository.BulkCreate(bookBorrowingRequestDetails);
            _bookRequestDetailRepository.SaveChanges();
        }

        public bool Delete(int id)
        {
            using (var transaction = _bookRequestDetailRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteBookRequest = _bookRequestDetailRepository.Get(c => c.Id == id);

                    if (deleteBookRequest != null)
                    {
                        bool result = _bookRequestDetailRepository.Delete(deleteBookRequest);

                        _bookRequestDetailRepository.SaveChanges();

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

        public IEnumerable<CreateRequestDetails> GetAll(Paging paging)
        { 
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CreateRequestDetails updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
