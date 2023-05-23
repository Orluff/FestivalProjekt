using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    // Denne klasse repræsenterer en service til håndtering af kategorier.
    public class CategoryService : ICategoryService
    {
        HttpClient http;

        // Konstruktøren for CategoryService-klassen.
        // Den modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        public CategoryService(HttpClient http)
        {
            this.http = http;
        }

        // Denne metode henter en liste af ShiftCategoryDTO-objekter fra serveren.
        // Den foretager en asynkron HTTP GET-anmodning til serverens API-endepunkt.
        public async Task<IEnumerable<ShiftCategoryDTO>> getCategories()
        {
            var cat = await http.GetFromJsonAsync<ShiftCategoryDTO[]>(Config.serverURL + "api/category");
            return cat;
        }

        // Denne metode tilføjer en ny kategori til serveren.
        // Den foretager en asynkron HTTP POST-anmodning til serverens API-endepunkt
        // med ShiftCategoryDTO-objektet som payload.
        public async Task AddCategory(ShiftCategoryDTO cat)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/category", cat);
        }
    }
}