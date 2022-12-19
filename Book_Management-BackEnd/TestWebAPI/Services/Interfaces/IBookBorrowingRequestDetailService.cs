using TestWebAPI.Models.Books;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestDetailService
    {
        void BulkCreate(List<CreateRequestDetails> createRequestDetails);

        IEnumerable<CreateRequestDetails> GetAll(Paging paging);

        void GetById(int id);

        void Update(int id, CreateRequestDetails updateRequestDetails);

        bool Delete(int id);
    }
}