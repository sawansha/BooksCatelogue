using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookApp.Filters;
using BookApp.Models;

namespace BookApp.Controllers
{
    [QueueMsg]
    public class BookController : ApiController
    {
        static readonly IBookRepository repository = new BookRepository();

        public IEnumerable<Book> GetAllBooks()
        {
            return repository.GetAllBooks();
        }
        public Book GetBookByISBN(string id)
        {
            Book book = repository.GetBookByISBN(id);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return book;
        }

        public IEnumerable<Book> GetBooksByAuthors(string id)
        {
            IEnumerable<Book> books = repository.GetBooksByAuthors(id);
            if ((books == null) || (books.Count() < 1))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return books;
        }
 
        public IEnumerable<Book> GetBooksByTitle(string id)
        {
            IEnumerable<Book> books = repository.GetBooksByTitle(id);
            if ((books == null) || ( books.Count() < 1))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return books;
        }


        public HttpResponseMessage PostBook(Book book)
        {
            book = repository.Add(book);
            var response = Request.CreateResponse<Book>(HttpStatusCode.Created, book);

            string uri = Url.Link("DefaultApi", new { id = book.ISBN });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public bool PutBook(string id, Book book)
        {
            if (repository.GetBookByISBN(id) == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            book.ISBN = id;
            return repository.Update(book);
        }

        public bool DeleteBook(string id)
        {
            Book book = repository.GetBookByISBN(id);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return repository.Remove(id);
        }
    }
}