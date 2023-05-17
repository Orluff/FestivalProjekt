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
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

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
                command.CommandText = "SELECT * FROM \"Shifts\" s JOIN \"ShiftCategories\" c ON s.category_id = c.category_id";

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
                        var category_id = reader.GetInt32(7);
                        var CategoryName = reader.GetString(8);
                        var Area = reader.GetString(9);
                        var Description = reader.GetString(10);

                        ShiftDTO a = new ShiftDTO
                        {
                            shift_id = ShiftID,
                            startDateTime = StartDateTime,
                            endDateTime = EndDateTime,
                            duration = Duration,
                            category_id = Category_id,
                            priority = Priority,
                            spots = Spots
                        };

                        //Vi joiner vores ShiftDTO med vores ShiftCategoryDTO
                        a.category = new ShiftCategoryDTO
                        {
                            category_id = category_id,
                            categoryName = CategoryName,
                            area = Area,
                            description = Description
                        };

                        result.Add(a);
                    }
                }
            }
            return result.ToArray();
        }

        public void AddShift(ShiftDTO shift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO \"Shifts\" (\"startDateTime\", \"endDateTime\", duration, category_id, priority, spots)" +
                    " VALUES (@startDateTime, @endDateTime, @duration, @category_id, @priority, @spots)";
                command.Parameters.AddWithValue("@startDateTime", shift.startDateTime);
                command.Parameters.AddWithValue("@endDateTime", shift.endDateTime);
                command.Parameters.AddWithValue("@duration", shift.duration);
                command.Parameters.AddWithValue("@category_id", shift.category_id);
                command.Parameters.AddWithValue("@priority", shift.priority);
                command.Parameters.AddWithValue("@spots", shift.spots);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveShift(int shift_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM \"Shifts\" WHERE shift_id = {shift_id};";
                command.ExecuteNonQuery();
            }
        }
    }
}

