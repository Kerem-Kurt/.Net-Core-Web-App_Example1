using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Crewin_Task.Models;

namespace Crewin_Task.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/products/categories");
            response.EnsureSuccessStatusCode();
            var categories = await response.Content.ReadFromJsonAsync<List<Category>>();
            return categories;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var response = await _httpClient.GetAsync($"https://dummyjson.com/products/category/{category}");
            response.EnsureSuccessStatusCode();
            var productResponse = await response.Content.ReadFromJsonAsync<ProductResponse>();
            return productResponse.Products;
        }
    }
}
