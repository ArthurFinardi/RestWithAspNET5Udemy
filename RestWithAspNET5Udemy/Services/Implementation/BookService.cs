using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Repository;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }
        public Book FindById(int id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }
        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _bookRepository.Exists(id);
        }
    }
}
