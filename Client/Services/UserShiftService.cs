using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    // Denne klasse repræsenterer en service til håndtering af brugerens vagter.
    public class UserShiftService : IUserShiftService
    {
        // Modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        HttpClient http;
        public UserShiftService(HttpClient http)
        {
            this.http = http;
        }

        // Henter en liste af UserShiftDTO-objekter fra serveren.
        // Laver en asynkron HTTP GET-anmodning til serverens API-endepunkt.
        // henter JSON-data fra API-endepunktet "api/usershift"
        public async Task<IEnumerable<UserShiftDTO>> GetUserShifts()
        {
            var userShifts = await http.GetFromJsonAsync<UserShiftDTO[]>(Config.serverURL + "api/usershift");
            return userShifts;
        }

        // Brugeren kan vælge en vagt.
        // Laver en asynkron HTTP POST-anmodning til serverens API-endepunkt
        // med UserShiftDTO-objektet som payload.
        public async Task TakeShift(UserShiftDTO userShift, ShiftDTO shift)
        {
            await http.PostAsJsonAsync<UserShiftDTO>(Config.serverURL + "api/usershift", userShift);
        }

        // Fjerner en brugers vagt fra serveren.
        // Laver en asynkron HTTP DELETE-anmodning til serverens API-endepunkt
        // med vagtens id som en del af URL'en.
        public async Task RemoveUserShift(ShiftDTO shift)
        {
            await http.DeleteAsync($"{Config.serverURL}api/usershift/{shift.shift_id}");
        }
    }
}