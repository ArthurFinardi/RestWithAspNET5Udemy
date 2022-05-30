using RestWithAspNET5Udemy.Data.VO;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Services
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(int id);

    }
}
