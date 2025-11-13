namespace BlazorTinyBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedDate {  get; set; }
        public bool IsPublished {  get; set; }

    }
}
