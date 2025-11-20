using BlazorTinyBlog.Data;
using BlazorTinyBlog.Shared.Models;
using BlazorTinyBlog.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTinyBlog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly DataContext _context;
        public BlogPostService(DataContext context)
        {
            _context= context;
        }
        public async  Task<int> CreateBlogPost(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteBlogPostAsync(int id)
        {
           var dbArticle = await _context.BlogPosts.FindAsync(id);
            if(dbArticle is not null)
            {
                _context.BlogPosts.Remove(dbArticle);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            return 0;
        }

        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            var posts = await _context.BlogPosts.ToListAsync();
            return posts;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var result = await _context.BlogPosts.FindAsync(id);
            return result;

        }

        public async Task<int> UpdateBlogPostAsync(int id, BlogPost post)
        {
            var dbArticle = await _context.BlogPosts.FindAsync(id);
            if (dbArticle is not null && post is not null)
            {
                dbArticle.Title = post.Title;
                dbArticle.PublishedDate = post.PublishedDate;
                dbArticle.Content = post.Content;
                dbArticle.IsPublished = post.IsPublished;

                var result = await _context.SaveChangesAsync();
                return result;
            }
            return 0;
        }
    }
}
