using Test.Data.Entities;
using TestWebAPI.Models;
using TestWebAPI.Models.Books;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public AddBookResponse? Create(AddBookRequest createModel)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepository.Get(s => s.CategoryId == createModel.CategoryId);

                    if (category != null)
                    {
                        var createBook = new Book
                        {
                            BookName = createModel.BookName,
                            PublishingYear = createModel.PublishingYear,
                            Description = createModel.Description,
                            Price =(int) createModel.Price,                
                            CategoryId = (int)category.CategoryId,
                        };
                        var book = _bookRepository.Create(createBook);

                        _bookRepository.SaveChanges();
                        transaction.Commit();

                        return new AddBookResponse
                        {
                            BookId = book.BookId,
                            BookName = book.BookName,
                            PublishingYear= book.PublishingYear,
                            Description= book.Description,
                            Price =(int) createModel.Price,                         
                            CategoryId = book.CategoryId
                        };
                    }

                    return null;
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
            using (var transaction = _bookRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteBook = _bookRepository.Get(p => p.BookId == id);

                    if (deleteBook != null)
                    {
                        bool result = _bookRepository.Delete(deleteBook);

                        _bookRepository.SaveChanges();

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

        public IEnumerable<GetBookResponse> GetAll(Paging paging)
        {
            var listBook = _bookRepository.GetAll(p => true)
            .Select(book => new GetBookResponse
            {
                BookId = book.BookId,
                BookName = book.BookName,
                PublishingYear = book.PublishingYear,
                Description = book.Description,
                Price = book.Price,               
                CategoryId = book.CategoryId
            }).Skip((paging.PageNumber - 1) * paging.PageSize)
              .Take(paging.PageSize)
              .ToList(); 

            return listBook;
        }

        public GetBookResponse GetById(int id)
        {
            var requestBook = _bookRepository.Get(p => p.BookId == id);

            if (requestBook != null)
            {
                return new GetBookResponse
                {
                    BookId = requestBook.BookId,
                    BookName = requestBook.BookName,
                    PublishingYear= requestBook.PublishingYear,
                    Description= requestBook.Description,
                    Price = requestBook.Price,                   
                    CategoryId = requestBook.CategoryId
                };
            }

            return null;
        }

        public UpdateBookResponse? Update(int id, UpdateBookRequest updateModel)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())
            {
                try
                {
                    var book = _bookRepository.Get(p => p.BookId == id);

                    if (book != null)
                    {
                        var category = _bookRepository.Get(c => c.CategoryId == updateModel.CategoryId);

                        if (category != null)
                        {
                            book.BookName = updateModel.BookName;
                            book.PublishingYear = updateModel.PublishingYear;
                            book.Description= updateModel.Description;
                            book.Price = updateModel.Price;
                            book.CategoryId = updateModel.CategoryId;

                            var updatedbook = _bookRepository.Update(book);

                            _bookRepository.SaveChanges();
                            transaction.Commit();

                            return new UpdateBookResponse
                            {
                                BookId = updatedbook.BookId,
                                BookName = updatedbook.BookName,
                                PublishingYear = updatedbook.PublishingYear,
                                Description= updatedbook.Description,
                                Price = updatedbook.Price,
                                CategoryId = updatedbook.CategoryId
                            };
                        }
                        
                        return null;
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
            }
        }
    }
}
