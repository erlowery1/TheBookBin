using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;

namespace api.Models
{
    public class SaveInfo : IInsert
    {
        public void InsertBook(Book value)
        {   
            string directory = Directory.GetCurrentDirectory();
            //Console.WriteLine(directory);
            string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            //Console.WriteLine(cs);
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

        public void InsertTransaction(Transaction value){
            string directory = Directory.GetCurrentDirectory();
            //Console.WriteLine(directory);
            string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            //Console.WriteLine(cs);
            //string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", value.Isbn);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Parameters.AddWithValue("@genre", value.Genre);
            cmd.Parameters.AddWithValue("@price", value.Price);
            cmd.Parameters.AddWithValue("@name", value.Name);
            cmd.Parameters.AddWithValue("@date", value.Date);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}