using BlazorTinyBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTinyBlog.Shared.Services
{
    public class ClientBlogService : IBlogPostService
    {
        private readonly HttpClient _httpClient;
        public ClientBlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> CreateBlogPost(BlogPost post)
        {
            var result = await _httpClient
                .PostAsJsonAsync("/api/blogpost", post);

            return await result.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> DeleteBlogPostAsync(int id)
        {
            var result = await _httpClient
                .DeleteAsync($"/api/blogpost/{id}");

            return await result.Content.ReadFromJsonAsync<int>();
        }

        public async  Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            var result = await _httpClient
                .GetFromJsonAsync<List<BlogPost>>("/api/blogpost");
            return result;
        }

        public async  Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<BlogPost>($"/api/blogpost/{id}");
            return result;
        }

        public async Task<int> UpdateBlogPostAsync(int id, BlogPost post)
        {
            var result = await _httpClient
                .PutAsJsonAsync($"/api/blogpost/{id}", post);
            return await result.Content.ReadFromJsonAsync<int>();
        }
    }
}