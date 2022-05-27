using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Repository.Interfaces;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class BookService : IBookService
    {
        private IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
        public Book FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
