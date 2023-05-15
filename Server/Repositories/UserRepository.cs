using System;
using System.Collections.Concurrent;
using Dapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Npgsql;

namespace Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public UserRepository()
        {
            
        }

        public UserDTO[] getUsers()
        {
            var result = new List<UserDTO>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM \"Users\"";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var UserID = reader.GetInt32(0);
                        Console.WriteLine("Id=" + UserID);
                        var Name = reader.GetString(1);
                        var Lastname = reader.GetString(2);
                        var Address = reader.GetString(3);
                        var Email = reader.GetString(4);
                        var Telephone = reader.GetString(5);
                        var Birthdate = reader.GetDateTime(6);
                        var RoleID = reader.GetInt32(7);

                        UserDTO b = new UserDTO { user_id = UserID, name = Name, lastName = Lastname, address = Address, email = Email, telephone = Telephone, birthDate = Birthdate, role_id = RoleID };
                        result.Add(b);
                    }
                }
            }
            return result.ToArray();
        }

        public void AddUser(UserDTO user)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO \"Users\" (name, \"lastName\", address, email, telephone, \"birthDate\", role_id, password)" +
                    " VALUES (@name, @lastName, @address, @email, @telephone, @birthDate, @role_id, @password)";
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@lastName", user.lastName);
                command.Parameters.AddWithValue("@address", user.address);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@telephone", user.telephone);
                command.Parameters.AddWithValue("@birthDate", user.birthDate);
                command.Parameters.AddWithValue("@role_id", user.role_id);
                command.Parameters.AddWithValue("@password", user.password);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveUser(int user_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                
            }
        }
    }
}

