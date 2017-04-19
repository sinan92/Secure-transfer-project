using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicSecurity.Data.DomainClasses;

namespace BasicSecurity.Data
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}
