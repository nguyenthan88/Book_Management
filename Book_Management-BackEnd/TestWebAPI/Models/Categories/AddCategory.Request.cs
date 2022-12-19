namespace TestWebAPI.Models.Categories
{
    public class AddCategoryRequest
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Description { get; set; }
    }
}