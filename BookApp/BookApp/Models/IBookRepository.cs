using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByAuthors(string authors);
        IEnumerable<Book> GetBooksByTitle(string title);
        Book GetBookByISBN(string isbn);
        Book Add(Book book);
        bool Remove(string isbn);
        bool Update(Book book);
    }
}
