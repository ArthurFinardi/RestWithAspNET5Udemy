using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Model.Context;
using RestWithAspNET5Udemy.Repository.Interfaces;
using System;
using System.Collections.Generic;


namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;
        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);   
        }
    }
}
