using System.Transactions;
namespace api.Models.Interfaces
{
    public interface IGet
    {
        Book GetBook(int id); 
        Transaction GetTransaction(int id); 
    }
}