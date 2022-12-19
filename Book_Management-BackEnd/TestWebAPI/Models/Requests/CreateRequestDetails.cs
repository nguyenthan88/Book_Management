namespace TestWebAPI.Models.Requests
{
    public class CreateRequestDetails
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int BookBorrowingRequestId { get; set; }
    }
}