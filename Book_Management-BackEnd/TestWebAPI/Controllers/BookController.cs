using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models;
using TestWebAPI.Models.Books;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public AddBookResponse? Add([FromBody] AddBookRequest addBookRequest)
        {
            return _bookService.Create(addBookRequest);
        }

        [HttpGet]
        public IEnumerable<GetBookResponse> GetAll([FromQuery] Paging paging)
        {
            return _bookService.GetAll(paging);
        }

        [HttpGet("{id}")]
        public GetBookResponse? GetById(int id)
        {
            return _bookService.GetById(id)
;
        }

        [HttpPut("{id}")]
        public UpdateBookResponse? Update(int id, [FromBody] UpdateBookRequest updateBookRequest)
        {
            return _bookService.Update(id, updateBookRequest);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _bookService.Delete(id)
;
        }
    }
}