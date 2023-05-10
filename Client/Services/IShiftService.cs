using System;
using Client;
namespace Client.Services
{
	public interface IShiftService
	{
		Task<IEnumerable<BookingItems>> getBookings();
		Task Book(BookingItems item);
		Task RemoveItem(BookingItems item);
	}
}

