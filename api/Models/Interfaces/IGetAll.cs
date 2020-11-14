using System.Transactions;
using System.Collections.Generic;

namespace api.Models.Interfaces
{
    public interface IGetAll
    {
         List<Book> GetAllBooks();
         List<Transaction> GetAllTransactions();
    }
}