using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Model.Context;
using RestWithAspNET5Udemy.Repository;
using System;
using System.Collections.Generic;


namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(int id)
        {
            return _personRepository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);   
        }
    }
}
