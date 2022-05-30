using RestWithAspNET5Udemy.Data.Converter.Implementations;
using RestWithAspNET5Udemy.Data.VO;
using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Repository.Interfaces;
using System.Collections.Generic;


namespace RestWithAspNET5Udemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);   
        }
    }
}
