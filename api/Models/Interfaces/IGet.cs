namespace api.Models.Interfaces
{
    public interface IGet
    {
        Book GetBook(int id); 
        Book GetTransaction(int id); 
    }
}