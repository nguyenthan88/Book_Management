using System.Linq.Expressions;
using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookBorrowingRequestRepository _bookRequestRepository;

        public BookBorrowingRequestService(IBookBorrowingRequestRepository bookRequestRepository)
        {
            _bookRequestRepository = bookRequestRepository;
        }

        public CreateReponse Create(CreateRequest createRequest)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())
            {
                try
                {
                    var bookRequestObj = new BookBorrowingRequest();
                    var createBorrowingRequest = new BookBorrowingRequest
                    {
                        RequestByUserId = createRequest.RequestByUserId,
                        RequestedDate = createRequest.RequestedDate,
                        Status = 1
                    };

                    bookRequestObj = _bookRequestRepository.Create(createBorrowingRequest);
                    _bookRequestRepository.SaveChanges();

                    transaction.Commit();

                    return new CreateReponse() { Id = bookRequestObj.Id };
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
            using (var transaction = _bookRequestRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteBookRequest = _bookRequestRepository.Get(c => c.Id == id);

                    if (deleteBookRequest != null)
                    {
                        bool result = _bookRequestRepository.Delete(deleteBookRequest);

                        _bookRequestRepository.SaveChanges();

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

        public IEnumerable<CreateRequest> GetAll(Expression<Func<BookBorrowingRequest, bool>>? predicate,
            Paging? paging,
            bool isPaging = false)
        {
            var bookRequestObj = _bookRequestRepository.GetAll(predicate);
            var lsCreateRequest = new List<CreateRequest>();

            foreach (var bookRequest in bookRequestObj)
            {
                lsCreateRequest.Add(new CreateRequest()
                {
                    Id = bookRequest.Id,
                    ProcessedByUserId = bookRequest.ProcessedByUserId,
                    RequestByUserId = bookRequest.RequestByUserId,
                    RequestedDate = bookRequest.RequestedDate,
                    Status = bookRequest.Status,
                });

            }
            return isPaging ? lsCreateRequest.Skip((paging.PageNumber - 1) * paging.PageSize)
                                            .Take(paging.PageSize)
                                            .ToList() : lsCreateRequest;
        }

        public IEnumerable<CreateRequest> GetAllRequestWithUserDetail(Paging paging)
        {
            var listRequest = _bookRequestRepository.GetAllRequestWithUserDetail(c => true).Select(c => new CreateRequest
            {
                Id = c.Id,
                UserName = c.RequestedBy.UserName,
                RequestByUserId = c.RequestByUserId,
                RequestedDate = c.RequestedDate,
                ProcessedByUserId = c.ProcessedByUserId,
                Status = c.Status,
            });

            return listRequest;
        }

        public void Update(int id, CreateRequest updateRequest)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())
            {
                try
                {
                    var bookBorrowingRequest = _bookRequestRepository.Get(c => c.Id == id);

                    if (bookBorrowingRequest != null)
                    {
                        bookBorrowingRequest.ProcessedByUserId = updateRequest.ProcessedByUserId;
                        bookBorrowingRequest.Status = updateRequest.Status;

                        var updatedCategory = _bookRequestRepository.Update(bookBorrowingRequest);

                        _bookRequestRepository.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch
                {
                    transaction.RollBack();
                }
            }
        }
    }
}