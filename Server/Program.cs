﻿namespace Server;

public class Program
{
    public static void Main(string[] args) 
    {
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

        app.UseCors("policy");

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection(); 

        app.UseAuthorization();

        app.MapControllers(); 

        app.Run();
    }
}
