using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using api.Models;
using System.Data.SQLite;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //if posts database doesnt exist at all, create it and seed it
            // string directory = Directory.GetCurrentDirectory();
            // string cs = @"URI = file:"+ directory+ @"\bookbin.db";
            // if(!System.IO.File.Exists(cs)){
            //     List<Book> allBooks = new List<Book>();
            //     SQLiteConnection.CreateFile(cs);
            //     //create connection string
            //     string connectionString = cs;
            //     //connecting to the database
            //     using var connection = new SQLiteConnection(connectionString);
            //     //open it up 
            //     connection.Open();

            //     using var command= new SQLiteCommand(connection);
            //     //create table w fields id, text, date
            //     command.CommandText = @"CREATE TABLE books (id INTEGER PRIMARY KEY, isbn INTEGER, title TEXT, author TEXT, genre TEXT, price FLOAT)";
            //     command.ExecuteNonQuery();
            //     ISeedData saveObject = new SaveData();
            //     saveObject.SeedData();
            // }
            //seeding the database
            // ISeedData saveObject = new SaveData();
            // saveObject.SeedData();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
