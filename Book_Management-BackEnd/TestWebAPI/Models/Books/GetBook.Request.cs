namespace TestWebAPI.Models.Books
{
    public class GetBookRequest
    {
        public int BookId { get; set; }

        public string? BookName { get; set; }

        public DateTime PublishingYear { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }
    }
}