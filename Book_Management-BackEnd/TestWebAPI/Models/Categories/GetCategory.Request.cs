namespace TestWebAPI.Models.Categories
{
    public class GetCategoryRequest
    {
        public int CategoryId { get; set; }

        public string? Description { get; set; }
    }
}