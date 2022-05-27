using RestWithAspNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
        bool Exists(int id);

    }
}
