using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;

namespace Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        //Connection string til PostgreSQL-databasen
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public UserRepository()
        {

        }

        //Hent brugere
        public UserDTO[] getUsers()
        {
            //Opret liste til at gemme UserDTO'er
            var result = new List<UserDTO>();

            //Opret forbindelse til database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Kommando til at udføre queries
                var command = connection.CreateCommand();

                //SQL-Query: Hent alt fra Users table
                command.CommandText = "SELECT * FROM \"Users\"";

                // Udfør forespørgslen og opret reader til at læse resultatet
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Læs/hent værdier
                        var UserID = reader.GetInt32(0);
                        Console.WriteLine("Id=" + UserID);
                        var Name = reader.GetString(1);
                        var Lastname = reader.GetString(2);
                        var Address = reader.GetString(3);
                        var Email = reader.GetString(4);
                        var Telephone = reader.GetString(5);
                        var Birthdate = reader.GetDateTime(6);
                        var RoleID = reader.GetInt32(7);
                        var Password = reader.GetString(8);

                        //Indsæt værdier i nyt UserDTO
                        UserDTO b = new UserDTO { user_id = UserID, name = Name, lastName = Lastname, address = Address, email = Email,
                            telephone = Telephone, birthDate = Birthdate, role_id = RoleID, password = Password };

                        // Tilføj UserDTO-objektet til resultatlisten
                        result.Add(b);
                    }
                }
            }
            // Konverter listen til et array og returner resultatet
            return result.ToArray();
        }

        //Tilføj bruger
        public void AddUser(UserDTO user)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Indsæt værdier i Users table
                command.CommandText = "INSERT INTO \"Users\" (name, \"lastName\", address, email, telephone, \"birthDate\", role_id, password)" +
                    " VALUES (@name, @lastName, @address, @email, @telephone, @birthDate, @role_id, @password)";

                //Tilføj værdier
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@lastName", user.lastName);
                command.Parameters.AddWithValue("@address", user.address);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@telephone", user.telephone);
                command.Parameters.AddWithValue("@birthDate", user.birthDate);
                command.Parameters.AddWithValue("@role_id", user.role_id);
                command.Parameters.AddWithValue("@password", user.password);

                //Udfører SQL-kommando uden at forvente et returneret resultat
                command.ExecuteNonQuery();
            }
        }

        //Opdater/rediger brugerinfo
        public void UpdateUser(UserDTO user)
        {

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                //SQL-Query: Opdater User table med nye værdier
                command.CommandText = "UPDATE \"Users\" SET \"name\" = @name, \"lastName\" = @lastName, address = @address, email = @email, telephone = @telephone, \"birthDate\" = @birthDate, \"password\" = @password WHERE user_id = @id";

                //Tilføj værdier
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@lastName", user.lastName);
                command.Parameters.AddWithValue("@address", user.address);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@telephone", user.telephone);
                command.Parameters.AddWithValue("@birthDate", user.birthDate);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@id", user.user_id);

                command.ExecuteNonQuery();
            }
        }

        //Fjern bruger
        public void RemoveUser(int user_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                //SQL-Query: Slet værdier fra Users table hvor user id'et = user_id
                command.CommandText = $"DELETE FROM \"Users\" WHERE user_id = {user_id};";

                command.ExecuteNonQuery();
            }
        }
    }
}
