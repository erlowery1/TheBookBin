using System.Collections.Generic;

namespace api.Models.Interfaces
{
    public interface IGetAllBooks
    {
         List<Book> GetAllBooks();
    }
}