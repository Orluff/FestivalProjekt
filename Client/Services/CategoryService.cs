﻿using System;
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
    }
}

