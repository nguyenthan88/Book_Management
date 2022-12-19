using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        public string? BookName { get; set; }

        public string? Description { get; set; }

        public DateTime PublishingYear { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public List<BookInCategory> BookInCategories { get; set; } = null!;

        public ICollection<BookBorrowingRequestDetails>? Details { get; set; }
    }
}