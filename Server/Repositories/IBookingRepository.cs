using System;
namespace Server.Repositories
{
    public interface IBookingRepository
    {
        BookingItems[] getBookings();
        ShelterItems[] getShelters();
        void Book(BookingItems item);
        void RemoveItems(int id);

       
    }
}
