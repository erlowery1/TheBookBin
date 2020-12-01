using System;
using MySql.Data.MySqlClient;
namespace api.Models
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;

        public DBConnect(){
            Initialize();
        }
        private void Initialize(){
            server = "sql9.freemysqlhosting.net";
            user = "sql9379553";
            password = "5s6vThe1hV";
            port = "3306";
            database = "sql9379553";

            string cs = "server="+server+";user="+user+";database="+database+";port="+port+";password="+password+";";
            connection= new MySqlConnection(cs);

        }
        public bool OpenConnection(){
            try{
                connection.Open();
                return true;
            }
            catch(MySqlException ex){
                if(ex.Number == 0){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Cannot connect");
                }else{
                    if(ex.Number == 1045){
                        Console.WriteLine("Invalid username/password combo");
                    }
                }
            }
            return false;
        }
        public bool CloseConnection(){
            try{
                connection.Close();
                return true;
            }
            catch(MySqlException ex){
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public MySqlConnection GetConn(){
            return connection;
        }
    }
}