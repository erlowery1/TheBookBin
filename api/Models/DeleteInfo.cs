using System.Security.AccessControl;
using System.Data.SQLite;
using api.Models.Interfaces;
using System.IO;
using System;

namespace api.Models
{
    public class DeleteInfo : IDelete
    {
        public void RemoveBook(int id){
            string directory = Directory.GetCurrentDirectory();
            //Console.WriteLine(directory);
            string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM books WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

    }
}