using BookApp.Controllers;
using BookApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BookAppTests
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void GetAllBooksTest()
        {
            BookController obj = new BookController();
            IEnumerable<Book> b = obj.GetAllBooks();
            Assert.IsNotNull(b);
        }
        
        [TestMethod]
        public void GetBookByISBNtest()
        {
            BookController obj = new BookController();
            Book b = obj.GetBookByISBN("1234567890123");
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void GetBooksByAuthorsTest()
        {
            BookController obj = new BookController();
            IEnumerable<Book> b = obj.GetBooksByAuthors("Sawan");
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void GetBooksByTitleTest()
        {
            BookController obj = new BookController();
            IEnumerable<Book> b = obj.GetBooksByTitle("MyBook");
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void PostBookTest()
        {
            BookController obj = new BookController();

            Book book = new Book();
            book.ISBN = "1234567890123";
            book.Authors = "Sawan";
            book.Title = "MyBook";
            book.PublicationDate = DateTime.Now;

            HttpResponseMessage res = obj.PostBook(book);

            Assert.AreEqual(res.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void PutBookTest()
        {
            BookController obj = new BookController();

            Book book = new Book();
            book.ISBN = "1234567890123";
            book.Authors = "Sawan";
            book.Title = "MyBook";
            book.PublicationDate = DateTime.Now;

            bool b = obj.PutBook(book.ISBN,book);

            Assert.AreEqual(b, true);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            BookController obj = new BookController();
            bool b = obj.DeleteBook("1234567890123");

            Assert.IsTrue(b);
        }
    }
}
