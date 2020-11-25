using System.Security.AccessControl;
using System.Data.SQLite;
using api.Models.Interfaces;
using System.IO;
using System;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class DeleteInfo : IDelete
    {
        //delete book with matching id
        public void RemoveBook(int id){
            // string directory = Directory.GetCurrentDirectory();
            // string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            DBConnect db = new DBConnect(); //create connection object
            bool isOpen = db.OpenConnection(); //open connection

            if(isOpen){ //if its connected:
                MySqlConnection conn = db.GetConn(); //set connection to variable
                MySqlCommand cmd = new MySqlCommand(); //create command

                cmd.Connection = conn; //set connection

                //delete book
                cmd.CommandText = @"DELETE FROM books WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }

            
        }

    }
}