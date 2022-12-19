using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Test.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public UserRoleEnum Role   { get; set; }

        public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; } // user stander

        public ICollection<BookBorrowingRequest>? ProcessedRequests { get; set; }     // user pro co ca 2
    }
}
