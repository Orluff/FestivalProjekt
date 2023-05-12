using System;
using System.Collections.Concurrent;
using Dapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Npgsql;

namespace Server.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private const string connString = "UserID=dulxtoup;Password=14RylFQESpWlaG33iASfr1zUZgyh5JyS;Host=abul.db.elephantsql.com;Port=5432;Database=dulxtoup;";

        public ShiftRepository()
        {
            
        }

        public ShiftDTO[] getShifts()
        {
            var result = new List<ShiftDTO>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM \"Shifts\"";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ShiftID = reader.GetInt32(0);
                        Console.WriteLine("Id=" + ShiftID);
                        var StartDateTime = reader.GetDateTime(1);
                        var EndDateTime = reader.GetDateTime(2);
                        var Duration = reader.GetDouble(3);
                        var Category_id = reader.GetInt32(4);
                        var Priority = reader.GetBoolean(5);
                        var Spots = reader.GetInt32(6);

                        ShiftDTO b = new ShiftDTO { shift_id = ShiftID, startDateTime = StartDateTime, endDateTime = EndDateTime, duration = Duration, category_id = Category_id, priority = Priority, spots = Spots };
                        result.Add(b);
                    }
                }
            }
            return result.ToArray();
        }

        public void AddShift(ShiftDTO shift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                /*
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"INSERT INTO Bike (Brand, Model, Description, Price, ImageUrl) VALUES ($brand, $model, $desc, $price, $imgurl)";
                command.Parameters.AddWithValue("$brand", bike.Brand);
                command.Parameters.AddWithValue("$model", bike.Model);
                command.Parameters.AddWithValue("$desc", bike.Description);
                command.Parameters.AddWithValue("$price", bike.Price);
                command.Parameters.AddWithValue("$imgurl", bike.ImageUrl);
                command.ExecuteNonQuery();
                */
            }
        }

        public void ReleaseShift(int shift_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                
            }
        }

        public void TakeShift(ShiftDTO shift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                
            }
        }

        /*
        ShiftDTO[] IShiftRepository.getShifts()
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                var users = connection.Query<UserDTO>(sql);

                return sql;
            }
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
        */
    }
}

