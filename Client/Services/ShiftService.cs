using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class ShiftService : IShiftService
    {
        HttpClient http;
        public ShiftService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<ShiftDTO>> getShifts()
        {
            var shifts = await http.GetFromJsonAsync<ShiftDTO[]>("https://localhost:7201/api/shift");
            return shifts;
        }

        public async Task AddShift(ShiftDTO shift)
        {
            await http.PostAsJsonAsync(Config.serverURL + "api/shift", shift);
        }

        public async Task RemoveShift(ShiftDTO shift)
        {
            await http.DeleteAsync($"https://localhost:7201/api/shift/{shift.shift_id}");
        }

        public async Task RemoveSpot(ShiftDTO shift)
        {
            await http.PutAsJsonAsync($"https://localhost:7201/api/shift/{shift.shift_id}", shift);
        }

    }
}