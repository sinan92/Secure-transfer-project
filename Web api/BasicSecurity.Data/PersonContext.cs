using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicSecurity.Data.DomainClasses;

namespace BasicSecurity.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("PersonContext") { }

        public DbSet<Person> Persons { get; set; }
    }
}
