using System;
using System.Collections.Concurrent;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private const string connectionString = @"mongodb+srv://admin:Uyq39fea@shelter.poainkb.mongodb.net/test";
        private const string databaseName = "shelterdb";
        private const string bookingCollection = "bookings";
        private const string shelterCollection = "shelters";
        public IMongoCollection<Shift> shift_collection;

        public ShiftRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            shift_collection = database.GetCollection<Shift>(bookingCollection);
        }

        Shift[] IShiftRepository.getShifts()
        {
            return shift_collection.Find(i => true).ToList().ToArray();
        }

        void IShiftRepository.AddShift(Shift item)
        {
            shift_collection.InsertOne(item);
        }

        void IShiftRepository.TakeShift(Shift item)
        {
            shift_collection.InsertOne(item);
        }

        void IShiftRepository.ReleaseShift(int id)
        {
            shift_collection.DeleteOne(item => item.shift_id == id);
        }
    }
}

