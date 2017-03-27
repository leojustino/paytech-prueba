using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paytech.Domain.Entities;
using Paytech.Domain.Repositories;

namespace Paytech.Repositories.EntityFrameworkImplementation
{
    class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository(DataContext context)
        {
            this.context = context;
        }

        DataContext context;

        public IEnumerable<Person> GetPeople()
        {
            return context
                .People
                .Include("Animals")
                .ToList();
        }

        public Person GetPerson(int id)
        {
            return context
                .People
                .Include("Animals")
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
