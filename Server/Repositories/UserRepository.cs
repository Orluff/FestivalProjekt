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
        private const string connString = "UserID=dulxtoup;Password=14RylFQESpWlaG33iASfr1zUZgyh5JyS;Host=abul.db.elephantsql.com;Port=5432;Database=dulxtoup;";

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

        public void RemoveUser(int user_id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                
            }
        }
    }
}

