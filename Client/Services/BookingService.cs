using System;
using System.Net.Http.Json;
using Client.Pages;
using Client;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class BookingService : IBookingService
    {
        HttpClient http;
        public BookingService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<BookingItems>> getBookings()
        {
            var bookings = await http.GetFromJsonAsync<BookingItems[]>("https://localhost:7201/api/booking");
            return bookings;
        }

        public async Task Book(BookingItems item)
        {
            await http.PostAsJsonAsync<BookingItems>("https://localhost:7201/api/booking", item);
        }

        public async Task RemoveItem(BookingItems item)
        {
            await http.DeleteAsync($"https://localhost:7201/api/booking/{item.BookingId}");
        }
    }
}