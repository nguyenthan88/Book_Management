using Test.Data.Entities;

namespace TestWebAPI.Models.Requests
{
    public class CreateRequest
    {
        public int Id { get; set; }

        public int RequestByUserId { get; set; }

        public string? UserName { get; set; }

        public int ProcessedByUserId { get; set; }

        public DateTime RequestedDate { get; set; }

        public int Status { get; set; }

        public List<Book>?  Books { get; set; }
    }
}