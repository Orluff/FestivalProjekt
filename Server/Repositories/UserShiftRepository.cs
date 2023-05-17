using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;

namespace Server.Repositories
{
    public class UserShiftRepository : IUserShiftRepository
    {
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public UserShiftRepository()
        {
            
        }

        public UserShiftDTO[] GetUserShifts()
        {
            var result = new List<UserShiftDTO>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM \"UserShifts\"";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var UserShiftID = reader.GetInt32(0);
                        var ShiftID = reader.GetInt32(1);
                        var UserID = reader.GetInt32(2);

                        UserShiftDTO b = new UserShiftDTO { shift_id = ShiftID, user_id = UserID };
                        result.Add(b);
                    }
                }
            }
            return result.ToArray();
        }

        public void TakeShift(UserShiftDTO userShift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO \"UserShifts\" (shift_id, user_id) VALUES()";
                command.Parameters.AddWithValue("@shift_id", userShift.shift_id);
                command.Parameters.AddWithValue("@user_id", userShift.user_id);
                command.ExecuteNonQuery();
            }
        }
    }
}

