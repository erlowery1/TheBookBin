using System.Transactions;
using System;
namespace api.Models
{
    public class Transaction : Book
    {
        public string Name{get;set;}
        public DateTime Date{get;set;}

        public Transaction(){
            
        }
        public override string ToString(){
            return Id + " " + Title +  " " + Author + " " + Genre+  " " + Isbn + " " + Price +  " " + Date + " " + Price;;
        }
    }
}