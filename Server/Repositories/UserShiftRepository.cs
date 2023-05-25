using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;

namespace Server.Repositories
{
    public class UserShiftRepository : IUserShiftRepository
    {
        //Connection string til PostgreSQL-databasen
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public UserShiftRepository()
        {
            
        }

        //Hent brugerens vagter
        public UserShiftDTO[] GetUserShifts()
        {
            //Opret liste til at gemme UserDTO'er
            var result = new List<UserShiftDTO>();

            //Opret forbindelse til database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Kommando til at udføre queries
                var command = connection.CreateCommand();

                //SQL-Query: Hent alt fra UserShifts table
                command.CommandText = "SELECT * FROM \"UserShifts\"";

                // Udfør forespørgslen og opret reader til at læse resultatet
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Læs/hent værdier
                        var UserShiftID = reader.GetInt32(0);
                        var UserID = reader.GetInt32(1);
                        var ShiftID = reader.GetInt32(2);

                        //Indsæt værdier i nyt UserShiftDTO
                        UserShiftDTO b = new UserShiftDTO {userShift_id = UserShiftID, shift_id = ShiftID, user_id = UserID };

                        // Tilføj UserShiftDTO-objektet til resultatlisten
                        result.Add(b);
                    }
                }
            }

            // Konverter listen til et array og returner resultatet
            return result.ToArray();
        }

        //Vælg vagt
        public void TakeShift(UserShiftDTO userShift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Indsæt værdier i UserShifts table, både ud fra shift_id og user_id
                command.CommandText = "INSERT INTO \"UserShifts\" (shift_id, user_id) VALUES(@shift_id, @user_id)";

                //Tilføj værdier
                command.Parameters.AddWithValue("@shift_id", userShift.shift_id);
                command.Parameters.AddWithValue("@user_id", userShift.user_id);

                //Udfører SQL-kommando uden at forvente et returneret resultat
                command.ExecuteNonQuery();
            }
        }

        //Fjern brugerens vagt
        public void RemoveShift(int shift_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                //SQL-Query: Slet værdier fra UsersShifts table hvor vagt id'et = shift_id
                command.CommandText = $"DELETE FROM \"UserShifts\" WHERE shift_id = {shift_id};";

                command.ExecuteNonQuery();
            }
        }
    }
}

