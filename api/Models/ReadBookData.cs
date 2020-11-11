using System;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using System.Security.Cryptography;

using System.Collections.Generic;
using System.Data.SQLite;
using api.Models.Interfaces;

namespace api.Models
{
    public class ReadBookData : IGetAllBooks, IGetBook
    {
        //returns a list of all books in the database
        public List<Book> GetAllBooks()
        {
            //string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine(directory);
            string cs = @"URI = file:"+ directory+ @"\bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * from books";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            List<Book> allBooks = new List<Book>();
            while(rdr.Read()){
                allBooks.Add(new Book{Id = rdr.GetInt32(0), Isbn = rdr.GetInt32(1), Title = rdr.GetString(2), Author = rdr.GetString(3), Genre = rdr.GetString(4), Price = rdr.GetDouble(5)});
            }

            return allBooks;
        }

        //finds a book with the matching id and returns the data
        public Book GetBook(int Id)
        {
            string cs = @"URI = file:C\Users\ellenlowery\source\repos\bookbin\bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * from books WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("id", Id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Book(){Id = rdr.GetInt32(0), Isbn = rdr.GetInt32(1), Title = rdr.GetString(2), Author = rdr.GetString(3), Genre = rdr.GetString(4), Price = rdr.GetDouble(5)};

        }
    }
}