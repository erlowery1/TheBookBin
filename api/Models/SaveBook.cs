using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;

namespace api.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {   
            string cs = Directory.GetCurrentDirectory() + @"/bookbin.db";
            Console.WriteLine(cs);
            //string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
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