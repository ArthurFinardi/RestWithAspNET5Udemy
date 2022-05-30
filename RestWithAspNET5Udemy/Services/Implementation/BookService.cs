using RestWithAspNET5Udemy.Data.Converter.Implementations;
using RestWithAspNET5Udemy.Data.VO;
using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Repository.Interfaces;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class BookService : IBookService
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public BookVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
