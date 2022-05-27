using RestWithAspNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);
        Book FindById(int id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(int id);
        bool Exists(int id);
    }
}
