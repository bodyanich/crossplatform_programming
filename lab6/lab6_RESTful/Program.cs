
using lab6_RESTful.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace lab6_RESTful
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://*:5001");

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


                string? databaseProvider = configuration.GetSection("Database")["Provider"];

                switch (databaseProvider)
                //switch (args[0]) For linux
                {
                    case "SqlServer":
                        options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
                        //options.UseSqlServer("Server=tcp:pro-lab3server.database.windows.net,1433;Initial Catalog=lab4_database;Persist Security Info=False;User ID=bohdan;Password=parol_bodya444;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                        break;
                    case "InMemory":
                        options.UseInMemoryDatabase(configuration.GetConnectionString("InMemoryConnection"));
                        //options.UseInMemoryDatabase("cross_lab5");
                        break;
                    case "Postgres":
                        options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
                        //options.UseNpgsql("Host=db-postgres;Database=postgres_bb;Username=postgres;Password=bohdan");
                        break;
                    case "Sqlite":
                        options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));
                        //options.UseSqlite("Data Source=App.db");
                        break;

                    default:
                        options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));
                        //options.UseSqlite("Data Source=App.db");
                        break;
                }
            });

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer("Server=tcp:pro-lab3server.database.windows.net,1433;Initial Catalog=lab4_database;Persist Security Info=False;User ID=bohdan;Password=parol_bodya444;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(a =>
            {
                a.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}