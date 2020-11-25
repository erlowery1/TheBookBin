using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class SaveInfo : IInsert
    {
        public void InsertBook(Book value)
        {   
            DBConnect db = new DBConnect(); //create connection object
            bool isOpen = db.OpenConnection(); //open connection

            if(isOpen){ //if its connected:
                MySqlConnection conn = db.GetConn(); //set connection to variable
                MySqlCommand cmd = new MySqlCommand(); //create command

                cmd.Connection = conn; //set connection

                //add book
                cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
                cmd.Parameters.AddWithValue("@isbn", value.Isbn);
                cmd.Parameters.AddWithValue("@title", value.Title);
                cmd.Parameters.AddWithValue("@author", value.Author);
                cmd.Parameters.AddWithValue("@genre", value.Genre);
                cmd.Parameters.AddWithValue("@price", value.Price);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
            // string directory = Directory.GetCurrentDirectory();
            // string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            
        }

        public void InsertTransaction(Transaction value){
            DBConnect db = new DBConnect(); //create connection object
            bool isOpen = db.OpenConnection(); //open connection

            if(isOpen){ //if its connected:
                MySqlConnection conn = db.GetConn(); //set connection to variable
                MySqlCommand cmd = new MySqlCommand(); //create command

                cmd.Connection = conn; //set connection

                //add transaction
                DateTime date = DateTime.Now; //getting current date time

                cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
                cmd.Parameters.AddWithValue("@isbn", value.Isbn);
                cmd.Parameters.AddWithValue("@title", value.Title);
                cmd.Parameters.AddWithValue("@author", value.Author);
                cmd.Parameters.AddWithValue("@genre", value.Genre);
                cmd.Parameters.AddWithValue("@price", value.Price);
                cmd.Parameters.AddWithValue("@name", value.Name);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
            // Console.WriteLine("made it to insert");
            // Console.WriteLine(value.Price);
            // string directory = Directory.GetCurrentDirectory();
            // //Console.WriteLine(directory);
            // string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            // //Console.WriteLine(cs);
            // //string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);
            // DateTime date = DateTime.Now; //getting current date time

            // cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            // cmd.Parameters.AddWithValue("@isbn", value.Isbn);
            // cmd.Parameters.AddWithValue("@title", value.Title);
            // cmd.Parameters.AddWithValue("@author", value.Author);
            // cmd.Parameters.AddWithValue("@genre", value.Genre);
            // cmd.Parameters.AddWithValue("@price", value.Price);
            // cmd.Parameters.AddWithValue("@name", value.Name);
            // cmd.Parameters.AddWithValue("@date", date);
            // cmd.Prepare();
            // cmd.ExecuteNonQuery();
        }
    }
}