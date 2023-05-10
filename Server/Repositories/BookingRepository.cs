using System;
using System.Collections.Concurrent;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private const string connectionString = @"mongodb+srv://admin:Uyq39fea@shelter.poainkb.mongodb.net/test";
        private const string databaseName = "shelterdb";
        private const string bookingCollection = "bookings";
        private const string shelterCollection = "shelters";
        public IMongoCollection<BookingItems> booking_collection;
        public IMongoCollection<ShelterItems> shelter_collection;

        public BookingRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            booking_collection = database.GetCollection<BookingItems>(bookingCollection);
            shelter_collection = database.GetCollection<ShelterItems>(shelterCollection);
        }

        BookingItems[] IBookingRepository.getBookings()
        {
            return booking_collection.Find(i => true).ToList().ToArray();
        }

        ShelterItems[] IBookingRepository.getShelters()
        {
            return shelter_collection.Find(i => true).ToList().ToArray();
        }

        void IBookingRepository.Book(BookingItems item)
        {
            item.BookingId = new Random().Next(1, 2000000);
            booking_collection.InsertOne(item);
        }
      
        void IBookingRepository.RemoveItems(int id)
        {
            booking_collection.DeleteOne(item => item.BookingId == id);
        }
    }
}

