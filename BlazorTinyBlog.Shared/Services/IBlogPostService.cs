using BlazorTinyBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTinyBlog.Shared.Services
{
    public  interface IBlogPostService
    {
        Task<List<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost> GetBlogPostByIdAsync(int id);
        Task<int> CreateBlogPost(BlogPost post);
        Task<int> UpdateBlogPostAsync(int id, BlogPost post);
        Task<int> DeleteBlogPostAsync(int id);

    }
}
