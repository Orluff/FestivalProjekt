using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;

namespace Server.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        //Connection string til PostgreSQL-databasen
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public ShiftRepository()
        {

        }

        //Hent vagter
        public ShiftDTO[] getShifts()
        {
            //Opret liste til at gemme ShiftDTO'er
            var result = new List<ShiftDTO>();

            // Opret forbindelse til database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Kommando til at udføre queries
                var command = connection.CreateCommand();

                //SQL-Query: Hent alt fra Shifts table
                command.CommandText = "SELECT * FROM \"Shifts\"";

                // Udfør forespørgslen og opret reader til at læse resultatet
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Hent/læs værdier
                        var ShiftID = reader.GetInt32(0);
                        Console.WriteLine("Id=" + ShiftID);
                        var StartDateTime = reader.GetDateTime(1);
                        var EndDateTime = reader.GetDateTime(2);
                        var Duration = reader.GetDouble(3);
                        var Category_id = reader.GetInt32(4);
                        var Priority = reader.GetBoolean(5);
                        var Spots = reader.GetInt32(6);

                        //Indsæt værdier i nyt ShiftDTO
                        ShiftDTO a = new ShiftDTO { shift_id = ShiftID, startDateTime = StartDateTime, endDateTime = EndDateTime,
                            duration = Duration, category_id = Category_id, priority = Priority, spots = Spots };

                        // Tilføj ShiftDTO-objektet til resultatlisten
                        result.Add(a);
                    }
                }
            }
            // Konverter listen til et array og returner resultatet
            return result.ToArray();
        }

        //Tilføj vagter
        public void AddShift(ShiftDTO shift)
        {

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Indsæt værdier i Shifts table
                command.CommandText = "INSERT INTO \"Shifts\" (\"startDateTime\", \"endDateTime\", duration, category_id, priority, spots)" +
                    " VALUES (@startDateTime, @endDateTime, @duration, @category_id, @priority, @spots)";

                //Tilføj værdier
                command.Parameters.AddWithValue("@startDateTime", shift.startDateTime);
                command.Parameters.AddWithValue("@endDateTime", shift.endDateTime);
                command.Parameters.AddWithValue("@duration", shift.duration);
                command.Parameters.AddWithValue("@category_id", shift.category_id);
                command.Parameters.AddWithValue("@priority", shift.priority);
                command.Parameters.AddWithValue("@spots", shift.spots);

                //Udfører SQL-kommando uden at forvente et returneret resultat
                command.ExecuteNonQuery();
            }
        }

        //Fjern vagt
        public void RemoveShift(int shift_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                //SQL-Query: Slet værdier fra Shifts table hvor vagt id'et = shift_id
                command.CommandText = $"DELETE FROM \"Shifts\" WHERE shift_id = {shift_id};";

                command.ExecuteNonQuery();
            }
        }

        //Fjern plads
        public void RemoveSpot(ShiftDTO shift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Opdater Shifts table, fjern 1 under antal pladser (spots) hvor vagt id'et = shift_id
                command.CommandText = "UPDATE \"Shifts\" SET spots = spots - 1 WHERE shift_id = @shiftId;";

                //Opdater ny værdi
                command.Parameters.AddWithValue("@shiftId", shift.shift_id);

                command.ExecuteNonQuery();
            }
        }

        //Tilføj plads
        public void AddSpot(ShiftDTO shift)
        {

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Opdater Shifts table, plus 1 under antal pladser (spots) hvor vagt id'et = shift_id
                command.CommandText = "UPDATE \"Shifts\" SET spots = spots + 1 WHERE shift_id = @shiftId;";

                //Opdater ny værdi
                command.Parameters.AddWithValue("@shiftId", shift.shift_id);

                command.ExecuteNonQuery();
            }
        }

        //Opdater/rediger vagt
        public void UpdateShift(ShiftDTO shift)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Opdater Shifts table med nye værdier
                command.CommandText = "UPDATE \"Shifts\" SET \"startDateTime\" = @startDateTime, \"endDateTime\" = @endDateTime, duration = @duration, priority = @priority, spots = @spots WHERE shift_id = @shiftId";

                //Tilføj værdier
                command.Parameters.AddWithValue("@shiftId", shift.shift_id);
                command.Parameters.AddWithValue("@startDateTime", shift.startDateTime);
                command.Parameters.AddWithValue("@endDateTime", shift.endDateTime);
                command.Parameters.AddWithValue("@duration", shift.duration);
                command.Parameters.AddWithValue("@priority", shift.priority);
                command.Parameters.AddWithValue("@spots", shift.spots);

                command.ExecuteNonQuery();
            }
        }
    }
}