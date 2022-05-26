using RestWithAspNET5Udemy.Model;
using RestWithAspNET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNET5Udemy.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private SQLServerContext _context;
        public PersonRepository(SQLServerContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(int id)
        {
            //return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            return _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(int id)
        {
            var result = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public Person Update(Person person)
        {
            
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.FirstOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        public bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
