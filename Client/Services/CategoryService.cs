using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class CategoryService : ICategoryService
    {
        HttpClient http;
        public CategoryService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<ShiftCategoryDTO>> getCategories()
        {
            var cat = await http.GetFromJsonAsync<ShiftCategoryDTO[]>(Config.serverURL + "api/category");
            return cat;
        }

        public async Task AddCategory(ShiftCategoryDTO cat)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/category", cat);
        }
    }
}
