using System;
using Npgsql;

namespace Server.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        //Connection string til PostgreSQL-databasen
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public RoleRepository()
        {

        }

        //Hent roller
        public RoleDTO[] getRole()
        {
            //Opret liste til at gemme RoleDTO'er
            var result = new List<RoleDTO>();

            // Opret forbindelse til database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Kommando til at udføre queries
                var command = connection.CreateCommand();

                //SQL-Query: Hent alt fra Roles table
                command.CommandText = "SELECT * FROM \"Roles\"";

                // Udfør forespørgslen og opret reader til at læse resultatet
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Hent/læs værdier
                        var role_id = reader.GetInt32(0);
                        var roleName = reader.GetString(1);
                        var description = reader.GetString(2);

                        //Indsæt værdier i nyt RoleDTO
                        RoleDTO a = new RoleDTO
                        {
                            role_id = role_id,
                            roleName = roleName,
                            description = description
                        };

                        // Tilføj RoleDTO-objektet til resultatlisten
                        result.Add(a);
                    }
                }
            }

            // Konverter listen til et array og returner resultatet
            return result.ToArray();
        }
    }
}
    




