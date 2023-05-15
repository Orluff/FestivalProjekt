using Npgsql;
using Dapper;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        var connString = "UserID=baune_admin;Password=Gruppe32023;Host=baunesfestival.postgres.database.azure.com;Port=5432;Database=postgres;";
        var sql = "SELECT * FROM \"Users\"";

        using (var connection = new NpgsqlConnection(connString))
        {
            var employees = connection.Query<UserDTO>(sql);

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.user_id}, {emp.name}, {emp.email}");
            }
        }

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                              policy =>
                              {
                                  policy.AllowAnyMethod();
                                  policy.AllowAnyOrigin();
                                  policy.AllowAnyHeader();
                              });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseCors("policy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

