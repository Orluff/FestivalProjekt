using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class UserShiftService : IUserShiftService
    {
        HttpClient http;
        public UserShiftService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<UserShiftDTO>> GetUserShifts()
        {
            var userShifts = await http.GetFromJsonAsync<UserShiftDTO[]>(Config.serverURL + "api/usershift");
            return userShifts;
        }

        public async Task TakeShift(UserShiftDTO userShift, ShiftDTO shift)
        {
            await http.PostAsJsonAsync<UserShiftDTO>(Config.serverURL + "api/usershift", userShift);
        }

        public async Task RemoveUserShift(ShiftDTO shift)
        {
            await http.DeleteAsync($"{Config.serverURL}api/usershift/{shift.shift_id}");
        }
    }
}