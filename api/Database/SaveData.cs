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
            cmd.CommandText = @"CREATE TABLE books (id INTEGER PRIMARY KEY, isbn TEXT, title TEXT, author TEXT, genre TEXT, price FLOAT)";
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9781427206374);
            cmd.Parameters.AddWithValue("@title", "Mistborn");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "Fantasy");
            cmd.Parameters.AddWithValue("@price", "11.25");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780575093331);
            cmd.Parameters.AddWithValue("@title", "Oathbringer");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "Fantasy");
            cmd.Parameters.AddWithValue("@price", "13.55");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Hunger Games");
            cmd.Parameters.AddWithValue("@author", "Suzanne Collins");
            cmd.Parameters.AddWithValue("@genre", "Fiction");
            cmd.Parameters.AddWithValue("@price", "9.22");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780439023481);
            cmd.Parameters.AddWithValue("@title", "The Great Gatsby");
            cmd.Parameters.AddWithValue("@author", "F. Scott Fitzgerald");
            cmd.Parameters.AddWithValue("@genre", "Tragedy");
            cmd.Parameters.AddWithValue("@price", "6.99");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780446310789);
            cmd.Parameters.AddWithValue("@title", "To Kill a Mockingbird");
            cmd.Parameters.AddWithValue("@author", "Harper Lee");
            cmd.Parameters.AddWithValue("@genre", "Southern Gothic");
            cmd.Parameters.AddWithValue("@price", "7.19");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //1
            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780446310789);
            cmd.Parameters.AddWithValue("@title", "Divergent");
            cmd.Parameters.AddWithValue("@author", "Veronica Roth");
            cmd.Parameters.AddWithValue("@genre", "Dystopian Fiction");
            cmd.Parameters.AddWithValue("@price", "4.30");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //2
            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780399501487 );
            cmd.Parameters.AddWithValue("@title", "Lord of the Flies");
            cmd.Parameters.AddWithValue("@author", "William Golding");
            cmd.Parameters.AddWithValue("@genre", "Young Adult Fiction");
            cmd.Parameters.AddWithValue("@price", "7.33");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //3
            cmd.CommandText = @"INSERT INTO books (isbn, title, author, genre, price) VALUES(@isbn, @title, @author, @genre, @price)";
            cmd.Parameters.AddWithValue("@isbn", 9780140177398);
            cmd.Parameters.AddWithValue("@title", "Of Mice and Men");
            cmd.Parameters.AddWithValue("@author", "John Steinbeck");
            cmd.Parameters.AddWithValue("@genre", "Fiction");
            cmd.Parameters.AddWithValue("@price", "7.19");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS transactions";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE transactions (id INTEGER PRIMARY KEY, isbn TEXT, title TEXT, author TEXT, genre TEXT, price FLOAT, name TEXT, date TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780451531353);
            cmd.Parameters.AddWithValue("@title", "The Scarlet Letter");
            cmd.Parameters.AddWithValue("@author", "Nathaniel Hawthorne");
            cmd.Parameters.AddWithValue("@genre", "Romanticism");
            cmd.Parameters.AddWithValue("@price", "5.05");
            cmd.Parameters.AddWithValue("@name" , "Jeff");
            cmd.Parameters.AddWithValue("@date", "2020-10-30 12:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780575093331);
            cmd.Parameters.AddWithValue("@title", "Oathbringer");
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson");
            cmd.Parameters.AddWithValue("@genre", "Fantasy");
            cmd.Parameters.AddWithValue("@price", "13.55");
            cmd.Parameters.AddWithValue("@name", "Ellen");
            cmd.Parameters.AddWithValue("@date", "2018-10-30 12:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9787543321724);
            cmd.Parameters.AddWithValue("@title", "The Catcher in the Rye");
            cmd.Parameters.AddWithValue("@author", "J. D. Salinger");
            cmd.Parameters.AddWithValue("@genre", "Fiction");
            cmd.Parameters.AddWithValue("@price", "9.22");
            cmd.Parameters.AddWithValue("@name", "Garrett");
            cmd.Parameters.AddWithValue("@date", "2020-03-06 12:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780810993136);
            cmd.Parameters.AddWithValue("@title", "Diary of a Wimpy Kid");
            cmd.Parameters.AddWithValue("@author", "Jeff Kinney");
            cmd.Parameters.AddWithValue("@genre", "Fiction");
            cmd.Parameters.AddWithValue("@price", "3.87");
            cmd.Parameters.AddWithValue("@name", "Noah");
            cmd.Parameters.AddWithValue("@date", "2010-12-25 12:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9781512308051);
            cmd.Parameters.AddWithValue("@title", "Frankenstein");
            cmd.Parameters.AddWithValue("@author", "Mary Shelley");
            cmd.Parameters.AddWithValue("@genre", "Gothic Fiction");
            cmd.Parameters.AddWithValue("@price", "7.19");
            cmd.Parameters.AddWithValue("@name", "Jake");
            cmd.Parameters.AddWithValue("@date", "2019-07-09 12:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780307278449);
            cmd.Parameters.AddWithValue("@title", "The Bluest Eye");
            cmd.Parameters.AddWithValue("@author", "Toni Morrison");
            cmd.Parameters.AddWithValue("@genre", "Fiction");
            cmd.Parameters.AddWithValue("@price", "6.29");
            cmd.Parameters.AddWithValue("@name", "Karen");
            cmd.Parameters.AddWithValue("@date", "2019-07-12 13:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO transactions (isbn, title, author, genre, price, name, date) VALUES(@isbn, @title, @author, @genre, @price, @name, @date)";
            cmd.Parameters.AddWithValue("@isbn", 9780593187982);
            cmd.Parameters.AddWithValue("@title", "Where the Crawdads Sing");
            cmd.Parameters.AddWithValue("@author", "Delia Owens");
            cmd.Parameters.AddWithValue("@genre", "Mystery");
            cmd.Parameters.AddWithValue("@price", "11.05");
            cmd.Parameters.AddWithValue("@name", "Robert");
            cmd.Parameters.AddWithValue("@date", "2020-11-23 10:12:12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}