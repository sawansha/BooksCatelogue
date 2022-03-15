using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApp.Models
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            string query = string.Format("SELECT [ISBN], [Authors], [Title], [PublicationDate] FROM [Northwind].[dbo].[Books]");

            using (SqlConnection con =
                    new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Book book = new Book();
                        book.ISBN = reader.GetString(0);
                        book.Authors = reader.GetString(1);
                        book.Title = reader.GetString(2);
                        book.PublicationDate = reader.GetDateTime(3);                                          
                        books.Add(book);
                    }
                    con.Close(); 
                }
            }
            return books.ToArray();
        }     

        public Book GetBookByISBN(string isbn)
        {
            Book book = null;
            string query = string.Format(" SELECT [ISBN], [Authors], [Title], [PublicationDate] FROM [Northwind].[dbo].[Books] " +
                "  WHERE ISBN = '" + isbn.Trim().ToUpper() + "'");

            using (SqlConnection con =
                     new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        book = new Book();
                        book.ISBN = reader.GetString(0);
                        book.Authors = reader.GetString(1);
                        book.Title = reader.GetString(2);
                        book.PublicationDate =reader.GetDateTime(3);
                    }
                    con.Close();
                }
            }
            return book;
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            List<Book> books = null;
            string query = string.Format(" SELECT [ISBN], [Authors], [Title], [PublicationDate] FROM [Northwind].[dbo].[Books] " +
                "  WHERE Title LIKE '%" + title + "%'");

            using (SqlConnection con =
                     new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    books = new List<Book>();
                    if (reader.HasRows)
                    {                        
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.ISBN = reader.GetString(0);
                            book.Authors = reader.GetString(1);
                            book.Title = reader.GetString(2);
                            book.PublicationDate = reader.GetDateTime(3);
                            books.Add(book);
                        }
                    }
                    con.Close();
                }
            }
            return books.ToArray();
        }
        public IEnumerable<Book> GetBooksByAuthors(string authors)
        {
            List<Book> books = null;
            string query = string.Format(" SELECT [ISBN], [Authors], [Title], [PublicationDate] FROM [Northwind].[dbo].[Books] " +
                "  WHERE Authors LIKE '%" + authors + "%'");

            using (SqlConnection con =
                     new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    books = new List<Book>();
                    if (reader.HasRows)
                    {                        
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.ISBN = reader.GetString(0);
                            book.Authors = reader.GetString(1);
                            book.Title = reader.GetString(2);
                            book.PublicationDate = reader.GetDateTime(3);
                            books.Add(book);
                        }
                    }
                    con.Close();
                }
            }
            return books.ToArray();
        }
        public Book Add(Book item)
        {            
            string query = string.Format("INSERT INTO [Northwind].[dbo].[Books] " +
                        " ( [ISBN], [Authors], [Title] " +
                        " , [PublicationDate]) VALUES " +
                       " ( '{0}', '{1}', '{2}', '{3}')", item.ISBN, item.Authors, item.Title, item.PublicationDate);

            using (SqlConnection con =
                    new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return item;
        }

        public bool Remove(string isbn)
        {
            string query = string.Format("DELETE FROM [Northwind].[dbo].[Books] WHERE ISBN LIKE '{0}'", isbn); 

            using (SqlConnection con =
                    new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return true;
        }

        public bool Update(Book book)
        {
            string query = string.Format("UPDATE [Northwind].[dbo].[Books] " +
                    " SET [ISBN] = '{0}'," +
                    " [Authors] = '{1}', " +
                    " [Title] = '{2}', " +
                    " [PublicationDate] = '{3}' " +
                    " WHERE ISBN LIKE '{0}'", book.ISBN, book.Authors, book.Title, book.PublicationDate);                    
            
            using (SqlConnection con =
                    new SqlConnection(@"Server=localhost\AMREXPRESS;Database=Northwind;User Id=sa;Password=Secure@123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return true;
        }

    }
}