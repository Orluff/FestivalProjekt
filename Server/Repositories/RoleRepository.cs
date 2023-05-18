using System;
using Npgsql;

namespace Server.Repositories
{
        public class RoleRepository : IRoleRepository
        {
            private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

            public RoleRepository()
            {
                Console.WriteLine();
            }

            public RoleDTO[] getRole()
            {
                var result = new List<RoleDTO>();
                using (var connection = new NpgsqlConnection(connString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM \"Roles\"";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var role_id= reader.GetInt32(0);
                            var roleName = reader.GetString(1);
                            var description = reader.GetString(2);

                            RoleDTO a = new RoleDTO
                            {
                                role_id = role_id,
                                roleName = roleName,
                                description = description
                            };

                            result.Add(a);
                        }
                    }
                }
                return result.ToArray();
            }

          
            }
        }
    




