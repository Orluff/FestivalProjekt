using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    // Denne klasse repræsenterer en service til håndtering af roller.
    public class RoleService : IRoleService
	{
        // Modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        HttpClient http;
        public RoleService(HttpClient http)
        {
            this.http = http; 
        }

        // Henter en liste af RoleDTO-objekter fra serveren.
        // Laver en asynkron HTTP GET-anmodning til serverens API-endepunkt
        // henter JSON-data fra API-endepunktet "api/role"
        public async Task<IEnumerable<RoleDTO>> getRole()
        {
            var role = await http.GetFromJsonAsync<RoleDTO[]>(Config.serverURL + "api/role");
            return role;
        }
    }
}


