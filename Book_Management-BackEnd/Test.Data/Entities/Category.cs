using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Description { get; set; }

        public List<BookInCategory> BookInCategories { get; set; } = null!;
    }
}
