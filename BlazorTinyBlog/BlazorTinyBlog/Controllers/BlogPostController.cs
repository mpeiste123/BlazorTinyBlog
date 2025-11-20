using BlazorTinyBlog.Shared.Models;
using BlazorTinyBlog.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTinyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetAllBlogPostsAsync()
        {
            var posts = await _blogPostService.GetAllBlogPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPostByIdAsync(int id )
        {
            var post = await _blogPostService.GetBlogPostByIdAsync(id);
            return Ok(post);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateBlogPostAsync(BlogPost post)
        {
            var result = await _blogPostService.CreateBlogPost(post);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateBlogPost(int id, BlogPost post)
        {
            var result = await _blogPostService.UpdateBlogPostAsync(id, post);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteBlogPost(int id)
        {
            var result = await _blogPostService.DeleteBlogPostAsync(id);
            return result;
        }
    }
}
