using System;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using System.IO;
namespace api.Database
{
    public class SaveData : ISeedData
    {
        public void SeedData(){
            string directory = Directory.GetCurrentDirectory();
            string cs = @"URI = file:"+ directory+ @"/bookbin.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS books";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE books (id INTEGER PRIMARY KEY, isbn INTEGER, title TEXT, author TEXT, genre TEXT, price FLOAT)";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9781427206374);
            cmd.Parameters.AddWithValue("@title", "Mistborn");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "fantasy");
            cmd.Parameters.AddWithValue("@price", "11.25");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780575093331);
            cmd.Parameters.AddWithValue("@title", "Oathbringer");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "fantasy");
            cmd.Parameters.AddWithValue("@price", "13.55");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Hunger Games");
            cmd.Parameters.AddWithValue("@author", "Suzanne Collins");
            cmd.Parameters.AddWithValue("@genre", "fiction");
            cmd.Parameters.AddWithValue("@price", "9.22");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Great Gatsby");
            cmd.Parameters.AddWithValue("@author", "F. Scott Fitzgerald");
            cmd.Parameters.AddWithValue("@genre", "tragedy");
            cmd.Parameters.AddWithValue("@price", "6.99");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780446310789);
            cmd.Parameters.AddWithValue("@title", "To Kill a Mockingbird");
            cmd.Parameters.AddWithValue("@author", "Harper Lee");
            cmd.Parameters.AddWithValue("@genre", "southern gothic");
            cmd.Parameters.AddWithValue("@price", "7.19");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS transactions";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE transactions (id INTEGER PRIMARY KEY, isbn INTEGER, title TEXT, author TEXT, genre TEXT, price FLOAT, name TEXT, date TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9781427206374);
            cmd.Parameters.AddWithValue("@title", "Mistborn");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "fantasy");
            cmd.Parameters.AddWithValue("@price", "11.25");
            cmd.Parameters.AddWithValue("@name" , "Jeff");
            cmd.Parameters.AddWithValue("@date", "11/13/2020");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780575093331);
            cmd.Parameters.AddWithValue("@title", "Oathbringer");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "fantasy");
            cmd.Parameters.AddWithValue("@price", "13.55");
            cmd.Parameters.AddWithValue("@name", "Ellen");
            cmd.Parameters.AddWithValue("@date", "11/11/2020");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Hunger Games");
            cmd.Parameters.AddWithValue("@author", "Suzanne Collins");
            cmd.Parameters.AddWithValue("@genre", "fiction");
            cmd.Parameters.AddWithValue("@price", "9.22");
            cmd.Parameters.AddWithValue("@name", "Garrett");
            cmd.Parameters.AddWithValue("@date", "11/08/2020");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Great Gatsby");
            cmd.Parameters.AddWithValue("@author", "F. Scott Fitzgerald");
            cmd.Parameters.AddWithValue("@genre", "tragedy");
            cmd.Parameters.AddWithValue("@price", "6.99");
            cmd.Parameters.AddWithValue("@name", "Noah");
            cmd.Parameters.AddWithValue("@date", "11/06/2020");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780446310789);
            cmd.Parameters.AddWithValue("@title", "To Kill a Mockingbird");
            cmd.Parameters.AddWithValue("@author", "Harper Lee");
            cmd.Parameters.AddWithValue("@genre", "southern gothic");
            cmd.Parameters.AddWithValue("@price", "7.19");
            cmd.Parameters.AddWithValue("@name", "Jake");
            cmd.Parameters.AddWithValue("@date", "10/22/2020");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}