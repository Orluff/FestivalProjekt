using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    // Denne klasse repræsenterer en service til håndtering af vagter.
    public class ShiftService : IShiftService
    {
        // Modtager en instans af HttpClient til at foretage HTTP-anmodninger.
        HttpClient http;
        public ShiftService(HttpClient http)
        {
            this.http = http;
        }

        // Henter en liste af ShiftDTO-objekter fra serveren.
        // Laver en asynkron HTTP GET-anmodning til serverens API-endepunkt.
        // henter JSON-data fra API-endepunktet "api/shift"
        public async Task<IEnumerable<ShiftDTO>> getShifts()
        {
            var shifts = await http.GetFromJsonAsync<ShiftDTO[]>(Config.serverURL + "api/shift");
            return shifts;
        }

        // Tilføjer en ny vagt til serveren.
        // Laver en asynkron HTTP POST-anmodning til serverens API-endepunkt
        // med ShiftDTO-objektet som payload.
        public async Task AddShift(ShiftDTO shift)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/shift", shift);
        }

        // Fjerner en vagt fra serveren.
        // Laver en asynkron HTTP DELETE-anmodning til serverens API-endepunkt
        // med vagtens id som en del af URL'en.
        public async Task RemoveShift(ShiftDTO shift)
        {
            await http.DeleteAsync($"{Config.serverURL}api/shift/{shift.shift_id}");
        }

        // Fjerner en plads fra en vagt på serveren.
        // Laver en asynkron HTTP PUT-anmodning til serverens API-endepunkt
        public async Task RemoveSpot(ShiftDTO shift)
        {
            await http.PutAsJsonAsync($"{Config.serverURL}api/shift/remove/{shift.shift_id}", shift);
        }

        // Tilføjer en plads til en vagt på serveren.
        public async Task AddSpot(ShiftDTO shift)
        {
            await http.PutAsJsonAsync($"{Config.serverURL}api/shift/add/{shift.shift_id}", shift);
        }

        // Opdaterer en vagt på serveren.
        public async Task UpdateShift(ShiftDTO shift)
        {
            await http.PutAsJsonAsync(Config.serverURL + "api/shift/", shift);
        }
    }
}