namespace TestWebAPI.Models.Requests
{
    public class BookBorrowingReponse
    {
        public int Id { get; set; }

        public int RequestByUserId { get; set; }

        public int ProcessedByUserId { get; set; }

        public DateTime RequestedDate { get; set; }

        public string? Status { get; set; }
    }
}