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

        public async Task<IEnumerable<Shift>> getShifts()
        {
            var shifts = await http.GetFromJsonAsync<Shift[]>("https://localhost:7201/api/booking");
            return shifts;
        }

        public async Task TakeShift(Shift item)
        {
            await http.PostAsJsonAsync<Shift>("https://localhost:7201/api/booking", item);
        }

        public async Task ReleaseShift(Shift item)
        {
            await http.DeleteAsync($"https://localhost:7201/api/booking/{item.BookingId}");
        }
    }
}