using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
	public class RoleService : IRoleService
	{
        HttpClient http;
        public RoleService(HttpClient http)
        {
            this.http = http; 
        }

        public async Task<IEnumerable<RoleDTO>> getRole()
        {
            var role = await http.GetFromJsonAsync<RoleDTO[]>("https://localhost:7201/api/role");
            return role;
        }

        /*public async Task AddRole(RoleDTO role)  
        {
            await http.PostAsJsonAsync<RoleDTO>("https://localhost:7201/api/role", role);
        }*/

     
    }
}


