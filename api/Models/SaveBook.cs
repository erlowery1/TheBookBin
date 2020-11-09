using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;

namespace api.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {
            string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre) VALUES(@isbn, @title, @author, @genre)";
            cmd.Parameters.AddWithValue("@isbn", value.Title);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Parameters.AddWithValue("@genre", value.Genre);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}