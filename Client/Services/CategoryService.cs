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

        // Modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        public CategoryService(HttpClient http)
        {
            this.http = http;
        }

        // Henter en liste af ShiftCategoryDTO-objekter fra serveren.
        // Laver en asynkron HTTP GET-anmodning til serverens API-endepunkt.
        // henter JSON-data fra API-endepunktet "api/category"
        public async Task<IEnumerable<ShiftCategoryDTO>> getCategories()
        {
            var cat = await http.GetFromJsonAsync<ShiftCategoryDTO[]>(Config.serverURL + "api/category");
            return cat;
        }

        // Tilføjer en ny kategori til serveren.
        // Laver en asynkron HTTP POST-anmodning til serverens API-endepunkt
        // med ShiftCategoryDTO-objektet cat som JSON-payload, altså det der skal tilføjes.
        public async Task AddCategory(ShiftCategoryDTO cat)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/category", cat);
        }
    }
}

