using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicSecurity.Data.DomainClasses;

namespace BasicSecurity.Data
{
    public class PersonContext2 : DbContext
    {
        public PersonContext2() : base("PersonContext2") { }

        public DbSet<Person> Persons { get; set; }
    }
}
