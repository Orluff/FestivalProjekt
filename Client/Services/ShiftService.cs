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
            var shifts = await http.GetFromJsonAsync<ShiftDTO[]>("https://localhost:7201/api/booking");
            return shifts;
        }

        public async Task TakeShift(ShiftDTO item)
        {
            await http.PostAsJsonAsync<ShiftDTO>("https://localhost:7201/api/booking", item);
        }

        public async Task ReleaseShift(ShiftDTO item)
        {
            await http.DeleteAsync($"https://localhost:7201/api/booking/{item.BookingId}");
        }
    }
}