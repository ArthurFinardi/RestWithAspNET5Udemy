using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Model.Context;
using RestWithAspNET5Udemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNET5Udemy.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private SQLServerContext _context;
        public BookRepository(SQLServerContext context)
        {
                _context = context;
        }
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public void Delete(int id)
        {
            var result = _context.Books.FirstOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return new Book();

            var result = _context.Persons.FirstOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public bool Exists(int id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }

    }
}
