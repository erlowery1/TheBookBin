using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;

namespace api.Models 
{
    public class Update : IUpdate
    {
        public void UpdateBook(int id, Book value){
            string directory = Directory.GetCurrentDirectory();
            string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            Console.WriteLine("isbn " + value.Isbn);
            Console.WriteLine("title " + value.Title);
            Console.WriteLine("author " + value.Author);
            Console.WriteLine("genre " + value.Genre);
            Console.WriteLine("price " + value.Price);
            cmd.CommandText = @"UPDATE books set isbn = @isbn, title = @title, author = @author, genre = @genre, price = @price WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.Parameters.AddWithValue("@isbn", value.Isbn);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Parameters.AddWithValue("@genre", value.Genre);
            cmd.Parameters.AddWithValue("@price", value.Price);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}