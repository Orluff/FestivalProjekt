using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;
namespace Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //Connection string til PostgreSQL-databasen
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public CategoryRepository()
        {

        }

        //Hent kategorier
        public ShiftCategoryDTO[] getCategories()
        {
            //Opret liste til at gemme ShiftCategoryDTO'er
            var result = new List<ShiftCategoryDTO>();

            // Opret forbindelse til database
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Kommando til at udføre queries
                var command = connection.CreateCommand();

                //SQL-Query: Hent alt fra ShiftCategories table
                command.CommandText = "SELECT * FROM \"ShiftCategories\"";

                // Udfør forespørgslen og opret reader til at læse resultatet
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Hent/læs værdier
                        var category_id = reader.GetInt32(0);
                        var categoryName = reader.GetString(1);
                        var description = reader.GetString(2);
                        var area = reader.GetString(3);

                        //Indsæt værdier i nyt ShiftCategoryDTO
                        ShiftCategoryDTO a = new ShiftCategoryDTO { category_id = category_id, categoryName = categoryName,
                            description = description, area = area };

                        // Tilføj ShiftCategoryDTO-objektet til resultatlisten
                        result.Add(a);
                    }
                }
            }
            // Konverter listen til et array og returner resultatet
            return result.ToArray();
        }
    }
}

