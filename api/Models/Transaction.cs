using System;
namespace api.Models
{
    public class Transaction : Book
    {
        string Name{get;set;}
        DateTime Date{get;set;}

        public override string ToString(){
            return Id + " " + Title +  " " + Author + " " + Genre+  " " + Isbn + " " + Price +  " " + Date + " " + Price;;
        }
    }
}