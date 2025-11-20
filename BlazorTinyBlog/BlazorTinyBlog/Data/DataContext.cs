
using BlazorTinyBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTinyBlog.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {  
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
