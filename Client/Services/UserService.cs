using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class UserService : IUserService
    {
        HttpClient http;
        public UserService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<UserDTO>> getUsers()
        {
            var users = await http.GetFromJsonAsync<UserDTO[]>("https://localhost:7201/api/user");
            return users;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var users = await getUsers();
            return users.FirstOrDefault(u => u.user_id == userId);
        }

        public async Task AddUser(UserDTO user)
        {
            await http.PostAsJsonAsync<UserDTO>("https://localhost:7201/api/user", user);
        }

        public async Task RemoveUser(UserDTO user)
        {
            await http.DeleteAsync($"https://localhost:7201/api/user/{user.user_id}");
        }
    }
}