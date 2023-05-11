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
        public IMongoCollection<ShiftDTO> shift_collection;

        public ShiftRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            shift_collection = database.GetCollection<ShiftDTO>(bookingCollection);
        }

        ShiftDTO[] IShiftRepository.getShifts()
        {
            return shift_collection.Find(i => true).ToList().ToArray();
        }

        void IShiftRepository.AddShift(ShiftDTO item)
        {
            shift_collection.InsertOne(item);
        }

        //SKAL REDIGERES - Tror jeg
        void IShiftRepository.TakeShift(ShiftDTO item)
        {
            shift_collection.InsertOne(item);
        }

        void IShiftRepository.ReleaseShift(int id)
        {
            shift_collection.DeleteOne(item => item.shift_id == id);
        }
    }
}

