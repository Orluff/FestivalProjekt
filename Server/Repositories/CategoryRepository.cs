using System;
using System.Collections.Concurrent;
using Dapper;
using Npgsql;
namespace Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private const string connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres";

        public CategoryRepository()
        {

        }

        public ShiftCategoryDTO[] getCategories()
        {
            var result = new List<ShiftCategoryDTO>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM \"ShiftCategories\"";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category_id = reader.GetInt32(0);
                        var categoryName = reader.GetString(1);
                        var description = reader.GetString(2);
                        var area = reader.GetString(3);

                        ShiftCategoryDTO a = new ShiftCategoryDTO
                        {
                            category_id = category_id,
                            categoryName = categoryName,
                            description = description,
                            area = area
                        };

                        result.Add(a);
                    }
                }
            }
            return result.ToArray();
        }

        public void AddCategory(ShiftCategoryDTO cat)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO \"ShiftCategories\" (\"category_id\" VALUES (@category_id)";
                command.Parameters.AddWithValue("@category_id", cat.category_id);
                command.ExecuteNonQuery();
            }
        }
    }
}

