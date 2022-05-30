using RestWithAspNET5Udemy.Data.VO;
using RestWithAspNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO person);
        BookVO FindById(int id);
        List<BookVO> FindAll();
        BookVO Update(BookVO person);
        void Delete(int id);
    }
}
