using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    // Denne klasse repræsenterer en service til håndtering af brugere.
    public class UserService : IUserService
    {
        // Modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        HttpClient http;
        public UserService(HttpClient http)
        {
            this.http = http;
        }

        // Henter en liste af UserDTO-objekter fra serveren.
        // Laver en asynkron HTTP GET-anmodning til serverens API-endepunkt.
        // henter JSON-data fra API-endepunktet "api/user"
        public async Task<IEnumerable<UserDTO>> getUsers()
        {
            var users = await http.GetFromJsonAsync<UserDTO[]>(Config.serverURL + "api/user");
            return users;
        }

        // Henter en bruger baseret på brugerens id.
        // Kalder getUsers() for at hente alle brugere og returnerer den første bruger,
        // der har samme id som det specificerede id.
        public async Task<UserDTO> GetUserById(int userId)
        {
            var users = await getUsers();
            return users.FirstOrDefault(u => u.user_id == userId);
        }

        // Tilføjer en ny bruger til serveren.
        // Laver en asynkron HTTP POST-anmodning til serverens API-endepunkt
        // med UserDTO-objektet som payload.
        public async Task AddUser(UserDTO user)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/user", user);
        }

        // Opdaterer en bruger på serveren.
        // Laver en asynkron HTTP PUT-anmodning til serverens API-endepunkt
        public async Task UpdateUser(UserDTO user)
        {
            await http.PutAsJsonAsync(Config.serverURL + "api/user/", user);
        }

        // Fjerner en bruger fra serveren.
        // Laver en asynkron HTTP DELETE-anmodning til serverens API-endepunkt
        // med brugerens id som en del af URL'en.
        public async Task RemoveUser(UserDTO user)
        {
            await http.DeleteAsync($"{Config.serverURL}api/user/{user.user_id}");
        }

    }
}