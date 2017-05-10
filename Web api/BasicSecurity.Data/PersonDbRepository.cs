using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicSecurity.Data.DomainClasses;
using BasicSecurity.Models;

namespace BasicSecurity.Data
{
    public class PersonDbRepository : IPersonRepository
    {
        private readonly PersonContext _personContext = new PersonContext();

        public IEnumerable<Person> GetAll()
        {
            return _personContext.Persons;
        }

        public Person Get(int id)
        {
            var result = (from person in _personContext.Persons where person.Id == id select person).FirstOrDefault();
            return result;
        }

        public Person Add(Person person)
        {
            var password = person.Password;
            var help = PasswordHash.HashPassword(password);
            var help2 = help.Split(':');
            var hash = help2[2];
            var salt = help2[1];

            person.Password = hash;
            person.Salt = salt;

            _personContext.Persons.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void Update(Person person)
        {
            _personContext.Entry(person).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Person person = _personContext.Persons.Find(id);
            _personContext.Persons.Remove(person);
            _personContext.SaveChanges();
        }
    }
}
