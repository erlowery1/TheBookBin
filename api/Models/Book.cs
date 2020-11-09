namespace api.Models
{
    public class Book
    {
        public string Title {get;set;}
        public string Author {get;set;}
        public int Isbn {get;set;}
        public string Genre{get;set;}
        public int Id{get;set;}

        public override string ToString(){
            return Id + " " + Title +  " " + Author + " " + Genre+  " " + Isbn;
        }
    }
}