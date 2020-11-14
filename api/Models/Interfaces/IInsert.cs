using System.Transactions;
namespace api.Models.Interfaces
{
    public interface IInsert
    {
         void InsertBook(Book value);
         void InsertTransaction(Transaction value);
    }
}