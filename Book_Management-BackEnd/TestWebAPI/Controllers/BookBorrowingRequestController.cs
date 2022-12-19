using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookBorrowingRequestController : ControllerBase
    {
        private readonly IBookBorrowingRequestService _bookBorrowingRequestService;
        private readonly IBookBorrowingRequestDetailService _bookBorrowingRequestDetailService;

        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestService,
            IBookBorrowingRequestDetailService bookBorrowingRequestDetailService)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
            /*_bookBorrowingRequestDetailService = bookBorrowingRequestDetailService;*/
        }

        [HttpPost]
        public GeneralResponse Add([FromBody] CreateRequest createRequest)
        {

            if (createRequest == null)
            {
                return new GeneralResponse()
                {
                    StatusCode = 0,
                    Message = " Can not Insert"
                };

            }
            Expression<Func<BookBorrowingRequest, bool>> expression = x => x.RequestedDate.Month >= DateTime.Now.Month;
            var allBookRequestInMonths = _bookBorrowingRequestService
                .GetAll(expression, null, false)
                .ToList();
            if (allBookRequestInMonths.Count <= 3 &&
                (createRequest.Books.Count >= 1 && createRequest.Books.Count <= 5))
            {
                var createReponse = _bookBorrowingRequestService.Create(createRequest);
                var createRequestDetails = new List<CreateRequestDetails>();

                if (createRequest.Books != null)
                {
                    foreach (var book in createRequest.Books)
                    {
                        createRequestDetails.Add(new CreateRequestDetails()
                        {
                            BookBorrowingRequestId = createReponse.Id,
                            BookId = book.BookId
                        });
                    }
                }
            }

            return new GeneralResponse()
            {
                StatusCode = 1,
                Message = "Insert Successfully"
            };
        }

        [HttpGet]
        public IEnumerable<CreateRequest> GetAll([FromQuery] Paging paging)
        {
            return _bookBorrowingRequestService.GetAllRequestWithUserDetail( paging);
        }  

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] CreateRequest updateRequest)
        {
            _bookBorrowingRequestService.Update(id, updateRequest);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _bookBorrowingRequestService.Delete(id);
        }
    }
}